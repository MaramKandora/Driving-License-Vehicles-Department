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
using DVLD_PresentationLayer.License;
using DVLD_PresentationLayer.License.International_Licenses;

namespace DVLD_PresentationLayer.Applications.Detain_And_Release_License
{
    public partial class frmDetainedLicensesList : Form
    {
        DataView _dvDetainedLicensesList;
        public frmDetainedLicensesList()
        {
            InitializeComponent();
        }

        void RefreshDetainedLicensesList()
        {
            _dvDetainedLicensesList = clsDetainedLicense.GetAllLicenses().DefaultView;
            dgvDetainedLicenses.DataSource = _dvDetainedLicensesList;
            lblRecordsNum.Text = dgvDetainedLicenses.RowCount.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 120;

                dgvDetainedLicenses.Columns[1].HeaderText = "License ID";
                dgvDetainedLicenses.Columns[1].Width = 120;

                dgvDetainedLicenses.Columns[2].HeaderText = "Detain Date";
                dgvDetainedLicenses.Columns[2].Width = 150;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 100;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 120;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 150;

                dgvDetainedLicenses.Columns[6].HeaderText = "National No";
                dgvDetainedLicenses.Columns[6].Width = 120;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 230;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 120;


            }
        }

        private void frmDetainedLicensesList_Load(object sender, EventArgs e)
        {
           
            RefreshDetainedLicensesList();
            cbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
            cbIsReleased.Visible = false;
            cbIsReleased.SelectedIndex = 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _dvDetainedLicensesList.RowFilter = "";
                lblRecordsNum.Text = dgvDetainedLicenses.RowCount.ToString();
                return;
            }


            if (cbFilter.SelectedItem.ToString() == "Detain ID")
            {
                _dvDetainedLicensesList.RowFilter = $"DetainID = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "License ID")
            {
                _dvDetainedLicensesList.RowFilter = $"LicenseID = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "Is Released")
            {
                _dvDetainedLicensesList.RowFilter = $"IsReleased = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "Release Application ID")
            {
                _dvDetainedLicensesList.RowFilter = $"ReleaseApplicationID = {txtFilter.Text.Trim()}";
            }
            else if (cbFilter.SelectedItem.ToString() == "National No.")
            {
                _dvDetainedLicensesList.RowFilter = $"NationalNo Like '{txtFilter.Text.Trim()}%'"; ;
            }
            else if (cbFilter.SelectedItem.ToString() == "Full Name")
            {
                _dvDetainedLicensesList.RowFilter = $"FullName Like '{txtFilter.Text.Trim()}%'"; ;

            }


            lblRecordsNum.Text = dgvDetainedLicenses.RowCount.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";

            if (cbFilter.Text == "Is Released")
            {
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
                txtFilter.Visible = false;
                return;
            }
            else
            {
                cbIsReleased.Visible = false;

                txtFilter.Visible = (cbFilter.Text != "None");
                txtFilter.Focus();


            }
        }

        private void frmDetainedLicensesList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "Detain ID" || cbFilter.SelectedItem.ToString() == "License ID"
                || cbFilter.SelectedItem.ToString() == "Release Application ID")
            {
                e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();   
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
           frmReleaseLicenseApplication frm = new frmReleaseLicenseApplication();
            frm.ShowDialog();   
        }

        private void btnClosePeopleManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.SelectedItem.ToString())
            {
                case "All":
                    _dvDetainedLicensesList.RowFilter = "";
                    break;

                case "Yes":
                    _dvDetainedLicensesList.RowFilter = "IsReleased = 1";
                    break;

                case "No":
                    _dvDetainedLicensesList.RowFilter = "IsReleased = 0";
                    break;
            }

            lblRecordsNum.Text = dgvDetainedLicenses.RowCount.ToString();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInformation PersonInfo = new frmPersonInformation(dgvDetainedLicenses.CurrentRow.Cells["NationalNo"].Value.ToString());
            PersonInfo.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDriverLicenseInfo IntLicenseInfo = new frmShowDriverLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            IntLicenseInfo.ShowDialog();
        }

        private void showPersonsLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = clsPerson.FindPerson(dgvDetainedLicenses.CurrentRow.Cells["NationalNo"].Value.ToString()).PersonID;
            frmShowPersonLicenseHistory LicensesHistory = new frmShowPersonLicenseHistory(PersonID);
            LicensesHistory.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicenseApplication frm = new frmReleaseLicenseApplication((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                frm.ShowDialog();
            RefreshDetainedLicensesList();
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToBoolean(dgvDetainedLicenses.CurrentRow.Cells["IsReleased"].Value) == true)
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            else
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
        }
    }
}
