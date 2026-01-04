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
using DVLD_PresentationLayer.Applications.Local_Driving_License;
using DVLD_PresentationLayer.License;
using DVLD_PresentationLayer.Tests;

namespace DVLD_PresentationLayer.Applications
{
    public partial class frmLocalDrivingLicenseApplicationsManagement : Form
    {

        DataView _dvLDLApplications ;

        public frmLocalDrivingLicenseApplicationsManagement()
        {
            InitializeComponent();
        }

        void RefreshLDLApplicationsList()
        {
            _dvLDLApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView;
            dgvLDLApplications.DataSource = _dvLDLApplications; 
            lblRecordsNum.Text = dgvLDLApplications.RowCount.ToString();

            if (dgvLDLApplications.RowCount > 0)
            {
                dgvLDLApplications.Columns[0].HeaderText = "L.D.L AppID";
                dgvLDLApplications.Columns[0].Width = 100;

                dgvLDLApplications.Columns[1].HeaderText = "Driving Class";
                dgvLDLApplications.Columns[1].Width = 220;

                dgvLDLApplications.Columns[2].HeaderText = "National No";
                dgvLDLApplications.Columns[2].Width = 100;

                dgvLDLApplications.Columns[3].HeaderText = "Full Name";
                dgvLDLApplications.Columns[3].Width = 250;

                dgvLDLApplications.Columns[4].HeaderText = "Application Date";
                dgvLDLApplications.Columns[4].Width = 130;

                dgvLDLApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLDLApplications.Columns[5].Width = 100;

                dgvLDLApplications.Columns[6].HeaderText = "Status";
                dgvLDLApplications.Columns[6].Width = 100;

            }
            cbFilterLDLApplications.SelectedIndex = 0;
        }

        private void frmLocalDrivingLicenseApplicationsManagement_Load(object sender, EventArgs e)
        {
            RefreshLDLApplicationsList();
           

        }

        private void cbFilterLDLApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterLDLApplications.Visible = (cbFilterLDLApplications.Text != "None");
            if(txtFilterLDLApplications.Visible)
            {
                txtFilterLDLApplications.Focus();
                txtFilterLDLApplications.Text = "";

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterLDLApplications_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterLDLApplications.Text))
            {
                _dvLDLApplications.RowFilter = "";
                lblRecordsNum.Text = dgvLDLApplications.RowCount.ToString();
                return;
            }

            string ColumnName = "";

            switch (cbFilterLDLApplications.SelectedItem.ToString())
            {
                case "L.D.L AppID":
                    ColumnName = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    ColumnName = "ApplicantPersonNationalNo";
                    break;

                case "Full Name":
                    ColumnName = "ApplicantPersonFullName";
                    break;

                case "Status":
                    ColumnName = "ApplicationStatus";
                    break;
            }

            if (ColumnName == "LocalDrivingLicenseApplicationID")
            {
                _dvLDLApplications.RowFilter = $"{ColumnName} = {txtFilterLDLApplications.Text.Trim()}";
            }
            else
            {
                _dvLDLApplications.RowFilter = $"{ColumnName} Like \'{txtFilterLDLApplications.Text.Trim()}%\'";
            }

            lblRecordsNum.Text = dgvLDLApplications.RowCount.ToString();
        }

        private void btnAddNewLDLApp_Click(object sender, EventArgs e)
        {
            Form frmNewLDLApp = new frmAddNew_UpdateLDLApplication();
            frmNewLDLApp.ShowDialog();

            RefreshLDLApplicationsList();
        }

        private void scheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLDLApplications.SelectedRows.Count == 0)
                return;

            if (MessageBox.Show("Are You Sure do you Want to Delete Selected Application Data? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int LDLApplicationID = (int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

               
                if (clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(LDLApplicationID))
                {
                    MessageBox.Show("Deletion Completed Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshLDLApplicationsList();
                }
                else
                {
                    MessageBox.Show("Deletion Failed because this Application has Records Linked to it", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUpdateLDLApp = new frmAddNew_UpdateLDLApplication((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            frmUpdateLDLApp.ShowDialog();

            RefreshLDLApplicationsList();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLDLApplications.SelectedRows.Count == 0)
                return;

            if (MessageBox.Show("Are You Sure do you Want to Cancel Selected Application ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                int LDLApplicationID = (int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
                clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(LDLApplicationID);
                

                if (LDLApp.Cancel())
                {
                    MessageBox.Show("Application has Canceled successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshLDLApplicationsList();
                }
                else
                {
                    MessageBox.Show("Canceling Application has Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalDrivingLicenseApplicationInfo LDLAppInfo = new frmShowLocalDrivingLicenseApplicationInfo((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            LDLAppInfo.ShowDialog();
            RefreshLDLApplicationsList();
        }

        private void frmLocalDrivingLicenseApplicationsManagement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterLDLApplications.SelectedItem.ToString() == "L.D.L AppID")
            {
                e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
            }
        }

   

      
        private void cmsLDLApplications_Opening(object sender, CancelEventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLAppInfo =
              clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            byte TotalPassedTest = Convert.ToByte(dgvLDLApplications.CurrentRow.Cells["PassedTests"].Value);
            bool LicenseExists = LDLAppInfo.IsLicenseIssued();

            showApplicationDetailsToolStripMenuItem.Enabled = true;
            showPersonsLicenseHistoryToolStripMenuItem.Enabled = true;


            editApplicationToolStripMenuItem.Enabled = (LDLAppInfo.enApplicationStatusID == clsApplication.enApplicationStatus.New);

            deleteApplicationToolStripMenuItem.Enabled = (LDLAppInfo.enApplicationStatusID == clsApplication.enApplicationStatus.New);
            cancelApplicationToolStripMenuItem.Enabled = (LDLAppInfo.enApplicationStatusID == clsApplication.enApplicationStatus.New);
            scheduleTestToolStripMenuItem.Enabled = (LDLAppInfo.enApplicationStatusID == clsApplication.enApplicationStatus.New)
                && (TotalPassedTest < 3);

            bool IsVisionTestPassed = LDLAppInfo.IsTestTypePassed(clsTestType.enTestType.VisionTest);
            bool IsWrittenTestPassed = LDLAppInfo.IsTestTypePassed(clsTestType.enTestType.WrittenTest);
            bool IsStreetTestPassed = LDLAppInfo.IsTestTypePassed(clsTestType.enTestType.StreetTest);



            if (scheduleTestToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !IsVisionTestPassed;
                scheduleWrittenTestToolStripMenuItem.Enabled = IsVisionTestPassed && !IsWrittenTestPassed;
                scheduleStreetTestToolStripMenuItem.Enabled = IsVisionTestPassed && IsWrittenTestPassed && !IsStreetTestPassed;
            }

            issueDrivingLicenseToolStripMenuItem.Enabled = (TotalPassedTest == 3) &&
                (LDLAppInfo.enApplicationStatusID == clsApplication.enApplicationStatus.New) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int BaseApplicationID =
                clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID
                ((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value).ApplicationID;
            int LicenseID = clsLicense.GetLicenseIDUsingApplicationID(BaseApplicationID);

            if (LicenseID != -1)
            {
                frmShowDriverLicenseInfo LicenseInfo = new frmShowDriverLicenseInfo(LicenseID);
                LicenseInfo.ShowDialog();   
            }
            else
            {
                MessageBox.Show("Showing License has failed","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }


        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTestAppointment frmScheduleTest = new frmScheduleTestAppointment((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value
                , clsTestType.enTestType.VisionTest);
            frmScheduleTest.ShowDialog();
            RefreshLDLApplicationsList();
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTestAppointment frmScheduleTest = new frmScheduleTestAppointment((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value
               , clsTestType.enTestType.WrittenTest);
            frmScheduleTest.ShowDialog();
            RefreshLDLApplicationsList();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTestAppointment frmScheduleTest = new frmScheduleTestAppointment((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value
           , clsTestType.enTestType.StreetTest);
            frmScheduleTest.ShowDialog();
            RefreshLDLApplicationsList();
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense IssueLicense = new frmIssueDrivingLicense((int)dgvLDLApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            IssueLicense.ShowDialog();
            RefreshLDLApplicationsList();
        }

        private void showPersonsLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPerson.FindPerson(dgvLDLApplications.CurrentRow.Cells["ApplicantPersonNationalNo"].Value.ToString()).PersonID;
            frmShowPersonLicenseHistory LicenseHistory = new frmShowPersonLicenseHistory(PersonID);
            LicenseHistory.ShowDialog();
        }
    }
}
