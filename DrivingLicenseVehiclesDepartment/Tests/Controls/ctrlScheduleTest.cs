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

namespace DVLD_PresentationLayer.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        int _LDLAppID;
        clsLocalDrivingLicenseApplication _LDLAppInfo;

        int _TestAppointmentID;
        clsTestAppointment _TestAppointmentInfo;

        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;

                switch(value)
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
        }

        enum enMode { AddNew, Update}
        enMode _Mode;

        enum enCreationMode { TestForFirstTime, RetakeTest}
        enCreationMode _CreationMode;
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        bool HandlePreviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblUserMessage.Text = "";
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    if (!_LDLAppInfo.IsTestTypePassed(clsTestType.enTestType.VisionTest))
                    {
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;    
                        lblUserMessage.Text = "Not Allowed to Attend Test : This person has not passed through vision test.";
                        return false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                        lblUserMessage.Text = "";
                        return true;
                    }
                   

                case clsTestType.enTestType.StreetTest:
                    if (!_LDLAppInfo.IsTestTypePassed(clsTestType.enTestType.WrittenTest))
                    {
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        lblUserMessage.Text = "Not Allowed to Attend Test : This person has not passed through Written test.";
                        return false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                        lblUserMessage.Text = "";
                        return true;
                    }

                default: 
                    return false;
                   
            }
        }

        bool HandleActiveTestConstraint()
        {
            if (_LDLAppInfo.IsThereActiveTestForTestType(TestTypeID))
            {
                lblUserMessage.Text = $"There is already an active test Appointment for \'{TestTypeID.ToString()}\' Test Type.";
                btnSave.Enabled = false;
                return false;
            }
            else
            {
                return true;    
            }
        }

        bool HandleAppointmentIsLockedConstraint()
        {
            if (_LDLAppInfo.IsTestTypePassed(TestTypeID))
            {
                lblUserMessage.Text = $"This Person Already passed this Test Type. Appointment Is Locked";
                btnSave.Enabled = false;
                return false;
            }
            else
            {
                return true;
            }
        }
        bool LoadAppointmentData()
        {
            _TestAppointmentInfo = clsTestAppointment.FindTestAppointmentByTestAppointmentID(_TestAppointmentID);

            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show("Error in Loading Schedule Test Form. Test Appointment ID is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return false;
            }

            if (DateTime.Compare(DateTime.Now, _TestAppointmentInfo.AppointmentDate) < 0)
                dtpDate.MinDate = DateTime.Now;
            else
                dtpDate.MinDate = _TestAppointmentInfo.AppointmentDate;

            dtpDate.Value = _TestAppointmentInfo.AppointmentDate;
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString(); 
            
            if (_TestAppointmentInfo.RetakeTestApplicationInfo != null)
            {
                lblRetakeTestAppID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
                lblRetakeTestFees.Text = _TestAppointmentInfo.RetakeTestApplicationInfo.Fees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblHeader.Text = "Schedule Retake Test";
            }
            else
            {
                lblRetakeTestAppID.Text ="N/A";
                lblRetakeTestFees.Text = "0.0";
                gbRetakeTestInfo.Enabled = false;
                lblHeader.Text = "Schedule  Test";
            }
            return true;
        }
        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            if (AppointmentID == -1) 
            {
                dtpDate.MinDate = DateTime.Now; 
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }

            _LDLAppID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID; 

            this._LDLAppInfo = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(LocalDrivingLicenseApplicationID);
            if (_LDLAppInfo == null)
            {
                MessageBox.Show("Error in Loading Schedule Test Form. Local driving license application ID is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;    
                return;
            }

           
            lblLDLAppID.Text =LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text =_LDLAppInfo.LicenseClassInfo.ClassName;
            lblFullName.Text =_LDLAppInfo.ApplicantPersonInfo.FullName;
            lblTrialCount.Text = _LDLAppInfo.GetTrialsOfTestType(TestTypeID).ToString();
            lblFees.Text = "0.0";
            lblFees.Text = clsTestType.FindTestType(TestTypeID).TestFees.ToString();

            if (_LDLAppInfo.IsTestForFirstTime(TestTypeID))
                _CreationMode = enCreationMode.TestForFirstTime;

            else
                _CreationMode = enCreationMode.RetakeTest;

            


            if (_CreationMode == enCreationMode.TestForFirstTime)
            {
                gbRetakeTestInfo.Enabled = false;
                lblHeader.Text = "Schedule Test";
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeTestFees.Text = "0.0";

            }
            else
            {


                gbRetakeTestInfo.Enabled = true;
                lblHeader.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
                lblRetakeTestFees.Text =
                    clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.RetakeTest).ApplicationFees.ToString();


            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeTestFees.Text)).ToString();

            if (_Mode == enMode.AddNew)
            {
                dtpDate.MinDate = DateTime.Now;
                lblFees.Text = clsTestType.FindTestType(TestTypeID).TestFees.ToString();

                _TestAppointmentInfo = new clsTestAppointment();

                if (!HandlePreviousTestConstraint())
                    return;

                if (!HandleActiveTestConstraint())
                    return;

                if (!HandleAppointmentIsLockedConstraint())
                    return;
            }
            else
            {
                if (!LoadAppointmentData())
                    return;
            }


          
        }

       

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
            lblUserMessage.Text = "";
        }
        public bool HandleRetakeTestApplication()
        {

            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTest)
            {

                clsApplication RetakeTestApplicationInfo = new clsApplication();
                RetakeTestApplicationInfo.enApplicationTypeID = clsApplicationType.enApplicationTypes.RetakeTest;
                RetakeTestApplicationInfo.ApplicantPersonID = _LDLAppInfo.ApplicantPersonID;
                RetakeTestApplicationInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                RetakeTestApplicationInfo.Fees =
                    clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.RetakeTest).ApplicationFees;
                RetakeTestApplicationInfo.enApplicationStatusID = clsApplication.enApplicationStatus.Completed;

                if (!RetakeTestApplicationInfo.Save())
                {
                    MessageBox.Show("Failed to create retake test application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                
                _TestAppointmentInfo.RetakeTestApplicationID = RetakeTestApplicationInfo.ApplicationID;

            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!HandleRetakeTestApplication())
                return;

            _TestAppointmentInfo.TestTypeID = TestTypeID;
            _TestAppointmentInfo.LocalDrivingLicenseApplicationID = _LDLAppID;
            _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointmentInfo.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointmentInfo.AppointmentDate = dtpDate.Value;
            

            if (_TestAppointmentInfo.Save())
            {
                MessageBox.Show("Save Completed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;

                
            
            }
            else
            {
                MessageBox.Show("Save has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
