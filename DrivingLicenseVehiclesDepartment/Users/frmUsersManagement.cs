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

namespace DVLD_PresentationLayer.Users
{
    public partial class frmUsersManagement : Form
    {

        DataView _dvUsersList;
        public frmUsersManagement()
        {
            InitializeComponent();
            _dvUsersList = clsUser.GetAllUsers().DefaultView;
        }
        
        

        void SetColumnsHeaderNames()
        {
            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 120;

            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 120;

            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 310;

            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 120;

            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 120;
        }
        void RefreshUsersList()
        {
            _dvUsersList = clsUser.GetAllUsers().DefaultView;
            dgvUsers.DataSource = _dvUsersList;
            lblRecordsNum.Text = dgvUsers.RowCount.ToString();
        }
        private void frmUsersManagement_Load(object sender, EventArgs e)
        { 
            RefreshUsersList();
            SetColumnsHeaderNames();

            cbFilterUsers.SelectedIndex = 0;
            txtFilterUsers.Visible = false; 
            cbYesNo.Visible = false;
            cbYesNo.SelectedIndex = 0;
           
        }

        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cbFilterUsers.SelectedItem.ToString() == "Is Active")
            {
                cbYesNo.Visible = true;
                txtFilterUsers.Visible = false;
                return;
            }

            if (cbFilterUsers.SelectedItem.ToString() != "None")
            {
                txtFilterUsers.Visible = true;
                cbYesNo.Visible = false;
            }
            else
            {
                txtFilterUsers.Visible = false ;
                cbYesNo.Visible = false;
            }
        }

        void FilterRowsUsingString(string ColumnName, string Value)
        {
            _dvUsersList.RowFilter = $"{ColumnName} Like '{Value}%'";
        }
        private void txtFilterUsers_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFilterUsers.Text))
            {
                RefreshUsersList();
                return;
            }

            if (cbFilterUsers.SelectedItem.ToString() == "Person ID")
            {
                _dvUsersList.RowFilter = $"PersonID = {txtFilterUsers.Text}";
            }
            else if (cbFilterUsers.SelectedItem.ToString() == "User ID")
            {
                _dvUsersList.RowFilter = $"UserID = {txtFilterUsers.Text}";
            }
            else
            {
                FilterRowsUsingString(cbFilterUsers.SelectedItem.ToString().Replace(" ", ""), txtFilterUsers.Text);
            }

            lblRecordsNum.Text = dgvUsers.RowCount.ToString();  
        }

        private void txtFilterUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterUsers.SelectedItem.ToString() == "User ID" || cbFilterUsers.SelectedItem.ToString() == "Person ID")
            {
                e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);  
            }
        }

        private void cbYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbYesNo.SelectedItem.ToString())
            {
                case "All":
                    RefreshUsersList();
                    break;

                case "Yes":
                    _dvUsersList.RowFilter = "IsActive = 1";
                    break;

                case "No":
                    _dvUsersList.RowFilter = "IsActive = 0";
                    break;
            }

            lblRecordsNum.Text = dgvUsers.RowCount.ToString();
        }
    }
}
