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

namespace DVLD_PresentationLayer.Drivers
{
    public partial class frmDriversList : Form
    {

        DataView _dvDriversList;
        public frmDriversList()
        {
            InitializeComponent();
        }


        void RefreshDriversList()
        {
            _dvDriversList = clsDriver.GetAllDrivers().DefaultView;
            dgvDrivers.DataSource = _dvDriversList;
            lblRecordsNum.Text = dgvDrivers.RowCount.ToString();

            if (dgvDrivers.RowCount > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 110;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 110;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 130;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 300;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 200;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 110;


            }

            cbDriversFilter.SelectedIndex = 0;

        }
        private void frmDriversList_Load(object sender, EventArgs e)
        {
            RefreshDriversList();

        }

        private void cbDriversFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDriversFilter.SelectedItem.ToString() == "None")
            {
                txtDriversFilter.Visible = false;
            }
            else
            {
                txtDriversFilter.Visible = true;
                txtDriversFilter.Focus();
                txtDriversFilter.Text = "";
            }
        }

        void FilterRowsUsingString(string ColumnName, string Value)
        {
            _dvDriversList.RowFilter = $"{ColumnName} Like '{Value}%'";
        }
        private void txtDriversFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDriversFilter.Text))
            {
                _dvDriversList.RowFilter = "";
                lblRecordsNum.Text = dgvDrivers.RowCount.ToString();
                return;
            }


            if (cbDriversFilter.SelectedItem.ToString() == "Person ID")
            {
                _dvDriversList.RowFilter = $"PersonID = {txtDriversFilter.Text.Trim()}";
            }
            else if (cbDriversFilter.SelectedItem.ToString() == "Driver ID")
            {
                _dvDriversList.RowFilter = $"DriverID = {txtDriversFilter.Text.Trim()}";
            }
            else if (cbDriversFilter.SelectedItem.ToString() == "Active Licenses Count")
            {
                _dvDriversList.RowFilter = $"NumberOfActiveLicenses = {txtDriversFilter.Text.Trim()}";
            }
            else
            {
                FilterRowsUsingString(cbDriversFilter.Text.Replace(" ", ""), txtDriversFilter.Text);
            }

            lblRecordsNum.Text = dgvDrivers.RowCount.ToString();
        }

        private void txtDriversFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbDriversFilter.SelectedItem.ToString() == "Driver ID" || cbDriversFilter.SelectedItem.ToString() == "Person ID"
                || cbDriversFilter.SelectedItem.ToString() == "Active Licenses Count")
            {
                e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
            }
        }

        private void btnClosePeopleManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInformation frm = new frmPersonInformation((int)dgvDrivers.CurrentRow.Cells["PersonID"].Value);
            frm.ShowDialog();
            RefreshDriversList();
        }

        private void showPersonsLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory((int)dgvDrivers.CurrentRow.Cells["PersonID"].Value);
            frm.ShowDialog();
            RefreshDriversList();
        }
    }
}
