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

namespace DVLD_PresentationLayer.License.International_Licenses
{
    public partial class frmInternationalLicensesManagement : Form
    {
        DataView _dvIntLicensesList;
        public frmInternationalLicensesManagement()
        {
            InitializeComponent();
        }

        void RefreshLicensesList()
        {
            _dvIntLicensesList = clsInternationalLicense.GetAllInternationalLicenses().DefaultView;
            dgvInternationalLicenses.DataSource = _dvIntLicensesList;
            lblRecordsNum.Text = dgvInternationalLicenses.RowCount.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 130;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 130;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 200;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 200;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 130;

            }


        }
        private void frmInternationalLicensesManagement_Load(object sender, EventArgs e)
        {

            RefreshLicensesList();

            cbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
            cbIsActive.Visible = false;
            cbIsActive.SelectedIndex = 0;

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";

            if (cbFilter.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                txtFilter.Visible = false;
                
            }
            else
            {
                cbIsActive.Visible = false;

                txtFilter.Visible = (cbFilter.Text != "None");
                txtFilter.Focus();


            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _dvIntLicensesList.RowFilter = "";
                lblRecordsNum.Text = dgvInternationalLicenses.RowCount.ToString();
                return;
            }


            if (cbFilter.SelectedItem.ToString() == "Int.License ID")
            {
                _dvIntLicensesList.RowFilter = $"InternationalLicenseID = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "Application ID")
            {
                _dvIntLicensesList.RowFilter = $"ApplicationID = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "Driver ID")
            {
                _dvIntLicensesList.RowFilter = $"DriverID = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "Local License ID")
            {
                _dvIntLicensesList.RowFilter = $"IssuedUsingLocalLicenseID = {txtFilter.Text.Trim()}";
            }

            lblRecordsNum.Text = dgvInternationalLicenses.RowCount.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
            
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.SelectedItem.ToString())
            {
                case "All":
                    _dvIntLicensesList.RowFilter = "";
                    break;

                case "Yes":
                    _dvIntLicensesList.RowFilter = "IsActive = 1";
                    break;

                case "No":
                    _dvIntLicensesList.RowFilter = "IsActive = 0";
                    break;
            }

            lblRecordsNum.Text = dgvInternationalLicenses.RowCount.ToString();
        }

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense NewIntLicense= new frmAddNewInternationalLicense();   
            NewIntLicense.ShowDialog();
            RefreshLicensesList();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDriver.FindDriverUsingDriverID((int)dgvInternationalLicenses.CurrentRow.Cells["DriverID"].Value).PersonID;
            frmPersonInformation PersonInfo = new frmPersonInformation(PersonID);
            PersonInfo.ShowDialog();
           
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo IntLicenseInfo = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells["InternationalLicenseID"].Value);
            IntLicenseInfo.ShowDialog();
        }

        private void showPersonsLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory LicensesHistory = new frmShowPersonLicenseHistory(); 
            LicensesHistory.ShowDialog(); 

        }

        private void btnClosePeopleManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
