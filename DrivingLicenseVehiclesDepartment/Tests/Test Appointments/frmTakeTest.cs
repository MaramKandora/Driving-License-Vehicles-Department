using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_PresentationLayer.Global_Classes;
using DVLD_PresentationLayer.Properties;

namespace DVLD_PresentationLayer.Tests.Test_Appointments
{
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID;
        clsTestAppointment _TestAppointmentInfo;
        clsTest _Test;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            this._TestAppointmentID = TestAppointmentID;    
           
        }

        enum enMode { AddNew, Update};
        enMode _Mode;

        void ShowLayoutAccordingToTestType()
        {
            switch (_TestAppointmentInfo.TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    gbMain.Text = "Vision Test";
                    pbHeaderImage.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    gbMain.Text = "Written Test";
                    pbHeaderImage.Image = Resources.Written_Test_512;
                    break;

                case clsTestType.enTestType.StreetTest:
                    gbMain.Text = "Street Test";
                    pbHeaderImage.Image = Resources.driving_test_512;
                    break;
            }
        }

        void LoadAppointmentInfo()
        {
            lblLDLAppID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _TestAppointmentInfo.LDLApplicationInfo.LicenseClassInfo.ClassName;
            lblFullName.Text = _TestAppointmentInfo.LDLApplicationInfo.ApplicantPersonInfo.FullName;
            lblTrialCount.Text = _TestAppointmentInfo.LDLApplicationInfo.GetTrialsOfTestType(_TestAppointmentInfo.TestTypeID).ToString();
            lblDate.Text =_TestAppointmentInfo.AppointmentDate.ToString("dd/MM/yyyy");
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
           
            _Test = clsTest.FindTestByAppointmentID(this._TestAppointmentID);
            if (_Test != null)
            {
                if (_Test.TestResult == true)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtNotes.Text = _Test.Notes;
                lblTestID.Text = _Test.TestID.ToString();
                _Mode = enMode.Update;
            }
            else
            {
                rbFail.Checked = true;
                txtNotes.Text = "";
                lblTestID.Text = "Not Taken Yet";
                _Mode = enMode.AddNew;
            }
          
            if (_TestAppointmentInfo.IsLocked == true)
            {
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                lblChangeResultMessage.Text = "Test Completed, Changing Result is not Allowed.";
            }
            else
            {
                rbFail.Enabled = true;
                rbPass.Enabled = true;
                lblChangeResultMessage.Text = "";
            }


        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
           
            _TestAppointmentInfo = clsTestAppointment.FindTestAppointmentByTestAppointmentID(_TestAppointmentID);
            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show("Error in Loading Take Test Form. TestAppointmentID is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


            ShowLayoutAccordingToTestType();
            LoadAppointmentInfo();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _Test = new clsTest();
                _Test.TestAppointmentID = this._TestAppointmentID;
                _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (rbPass.Checked)
                {
                    _Test.TestResult = true;
                    
                }
                else
                    _Test.TestResult = false;
            }


            _Test.Notes =txtNotes.Text;

           

            if (MessageBox.Show("Are you sure do you want to Save Changes?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                if (_Test.Save())
                {
                    lblTestID.Text = _Test.TestID.ToString();
                    _TestAppointmentInfo.IsLocked = true;
                    if (_TestAppointmentInfo.Save())
                    {
                        if (_Mode == enMode.AddNew)
                            _Mode = enMode.Update;
                        MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rbFail.Enabled = false;
                        rbPass.Enabled = false;
                        lblChangeResultMessage.Text= "Test Completed, Changing Result is not Allowed.";
                    }
                    else
                        MessageBox.Show("Save has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Save has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
           
        }
    }
}
