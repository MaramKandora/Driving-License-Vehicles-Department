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
        }

        private void frmLocalDrivingLicenseApplicationsManagement_Load(object sender, EventArgs e)
        {
            RefreshLDLApplicationsList();
            if (dgvLDLApplications.RowCount > 0)
            {
                dgvLDLApplications.Columns[0].HeaderText = "L.D.L AppID";
                dgvLDLApplications.Columns[0].Width = 100;

                dgvLDLApplications.Columns[1].HeaderText = "Driving Class";
                dgvLDLApplications.Columns[1].Width = 220;

                dgvLDLApplications.Columns[2].HeaderText = "National No";
                dgvLDLApplications.Columns[2].Width = 100;

                dgvLDLApplications.Columns[3].HeaderText = "Full Name";
                dgvLDLApplications.Columns[3].Width = 220;

                dgvLDLApplications.Columns[4].HeaderText = "Application Date";
                dgvLDLApplications.Columns[4].Width = 120;

                dgvLDLApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLDLApplications.Columns[5].Width = 100;

                dgvLDLApplications.Columns[6].HeaderText = "Status";
                dgvLDLApplications.Columns[6].Width = 100;

            }
            cbFilterLDLApplications.SelectedIndex = 0;

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

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
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

        void ShowCompletedMode_cmsLDLApplications()
        {

            //TODO : come here after finishing license class
           
            deleteApplicationToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;   
            cancelApplicationToolStripMenuItem.Enabled = false; 
            scheduleStreetTestToolStripMenuItem.Enabled = false;    
            issueDrivingLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = true;

        }

        void ShowCanceledMode_cmsLDLApplications()
        {
            deleteApplicationToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleStreetTestToolStripMenuItem.Enabled = false;
            issueDrivingLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
        }

        void ShowNewMode_cmsLDLApplications(byte PassedTests)
        {
            deleteApplicationToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            scheduleStreetTestToolStripMenuItem.Enabled = true;
            issueDrivingLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;


            if (PassedTests == 0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled= false; 
            }
            else if (PassedTests == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (PassedTests == 2)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
        }
        private void cmsLDLApplications_Opening(object sender, CancelEventArgs e)
        {
            switch ((clsApplication.enApplicationStatus)dgvLDLApplications.CurrentRow.Cells["ApplicationStatus"].Value)
            {
                case clsApplication.enApplicationStatus.Completed:
                    ShowCompletedMode_cmsLDLApplications();
                    break;

                case clsApplication.enApplicationStatus.Canceled:
                    ShowCanceledMode_cmsLDLApplications();
                    break;

                case clsApplication.enApplicationStatus.New:
                    ShowNewMode_cmsLDLApplications((byte)dgvLDLApplications.CurrentRow.Cells["PassedTests"].Value);
                    break;
                    
            }
        }
    }
}
