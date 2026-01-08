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

        public event Action OnDeleteCurrentUser;

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
            cbFilterUsers.SelectedIndex = 0;
            lblRecordsNum.Text = dgvUsers.RowCount.ToString();
        }
        private void frmUsersManagement_Load(object sender, EventArgs e)
        { 
            RefreshUsersList();

            if (dgvUsers.Rows.Count > 0)
                SetColumnsHeaderNames();

            cbFilterUsers.SelectedIndex = 0;
            txtFilterUsers.Visible = false; 
            cbIsActive.Visible = false;
            cbIsActive.SelectedIndex = 0;
           
        }

        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterUsers.Text = "";

            if (cbFilterUsers.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                txtFilterUsers.Visible = false;
                return;
            }
            else
            {
                cbIsActive.Visible = false;

                txtFilterUsers.Visible = (cbFilterUsers.Text != "None");
                txtFilterUsers.Focus();


            }
                

           
        }

        void FilterRowsUsingString(string ColumnName, string Value)
        {
            _dvUsersList.RowFilter = $"{ColumnName} Like '{Value}%'";
        }
        private void txtFilterUsers_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterUsers.Text)) 
            {
                _dvUsersList.RowFilter = "";
                lblRecordsNum.Text = dgvUsers.RowCount.ToString();
                return;
            }


            if (cbFilterUsers.SelectedItem.ToString() == "Person ID")
            {
                _dvUsersList.RowFilter = $"PersonID = {txtFilterUsers.Text.Trim()}";
            }
            else if (cbFilterUsers.SelectedItem.ToString() == "User ID")
            {
                _dvUsersList.RowFilter = $"UserID = {txtFilterUsers.Text.Trim()}";
            }
            else
            {
                FilterRowsUsingString(cbFilterUsers.Text.Replace(" ", ""), txtFilterUsers.Text);
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

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.SelectedItem.ToString())
            {
                case "All":
                    _dvUsersList.RowFilter = "";
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

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form AddNewUser = new frmAddNew_UpdateUser();
            AddNewUser.ShowDialog();
            RefreshUsersList();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AddNewUser = new frmAddNew_UpdateUser();
            AddNewUser.ShowDialog();
            RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNew_UpdateUser UpdateUser = new frmAddNew_UpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            UpdateUser.ShowDialog();
            RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedUserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to Delete Selected User?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(SelectedUserID))
                {
                    MessageBox.Show("User Deleted Successfully", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUsersList();

                    if (SelectedUserID == clsGlobal.CurrentUser.UserID)
                    {
                        
                        OnDeleteCurrentUser?.Invoke();
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Deletion Failed. User has Data Linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ChangePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            ChangePassword.ShowDialog();
            RefreshUsersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UserInfo = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            UserInfo.ShowDialog();
        }

       

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form UserInfo = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            UserInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature has not been built yet", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature has not been built yet", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
