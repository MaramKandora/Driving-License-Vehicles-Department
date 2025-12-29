using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_PresentationLayer.Properties;
using DVLD_PresentationLayer.Tests.Test_Appointments;

namespace DVLD_PresentationLayer.Tests
{
    public partial class frmScheduleTestAppointment : Form
    {
        int _LDLAppID;
        clsLocalDrivingLicenseApplication _LDLAppInfo;
        DataView _dvAppointmentsList;
        public frmScheduleTestAppointment(int LDLAppID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            this._LDLAppID = LDLAppID;
            this._TestType = TestType;   
            
        }

       
       clsTestType.enTestType _TestType ;


        void RefreshAppointmentsList()
        {
            _dvAppointmentsList = clsTestAppointment.GetAllTestAppointmentsUsingLDLAppIDAndTestType(_LDLAppID, _TestType).DefaultView;
            dgvAppointments.DataSource =_dvAppointmentsList;
            lblRecordsNum.Text = dgvAppointments.RowCount.ToString();

            if (dgvAppointments.RowCount > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 200;

                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAppointments.Columns[1].Width = 200;

                dgvAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvAppointments.Columns[2].Width = 200;

                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                dgvAppointments.Columns[3].Width = 200;

            }
        }

        void ShowLayoutAccordingToTestType()
        {
            switch (_TestType)
            {
               case clsTestType.enTestType.VisionTest:
                    this.Text = "Vision Test Appointments";
                    lblHeader.Text = "Vision Test Appointments";
                    pbHeaderImage.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    this.Text = "Written Test Appointments";
                    lblHeader.Text = "Written Test Appointments";
                    pbHeaderImage.Image = Resources.Written_Test_512;
                    break;

                case clsTestType.enTestType.StreetTest:
                    this.Text = "Street Test Appointments";
                    lblHeader.Text = "Street Test Appointments";
                    pbHeaderImage.Image = Resources.driving_test_512;
                    break;
            }
        }
        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            ShowLayoutAccordingToTestType();

            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfoUsingLDLAppID(_LDLAppID);

            _LDLAppInfo = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(_LDLAppID);
            if (_LDLAppInfo == null)
            {
                MessageBox.Show("Loading Failed, LDLAppID is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            RefreshAppointmentsList();
            
           
        }

        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
           
            if (_LDLAppInfo.IsTestTypePassed(_TestType))
            {
                MessageBox.Show("This Person Already Passed this Test before. you can only retake Failed Tests", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);    

            }
            else if(_LDLAppInfo.IsThereActiveTestForTestType(_TestType))
            {
                MessageBox.Show("This Person Already Have an Active Test Appointment for Test Type. you can not add new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                frmScheduleTest frmScheduleTest = new frmScheduleTest(_LDLAppID, _TestType);
                frmScheduleTest.ShowDialog();
                RefreshAppointmentsList();
              
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) 
                return;
            frmTakeTest TakeTest = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            TakeTest.ShowDialog();
            RefreshAppointmentsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
                return;
            frmScheduleTest frmTestAppointment = new frmScheduleTest(_LDLAppID, _TestType, (int)dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);
            frmTestAppointment.ShowDialog();
            RefreshAppointmentsList();
        }
    }
}
