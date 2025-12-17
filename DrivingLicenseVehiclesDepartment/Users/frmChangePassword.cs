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

namespace DVLD_PresentationLayer.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _User;

        bool _ValuesChanged;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _ValuesChanged = false;
        }

        void ShowPasswordsDefaultValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ShowPasswordsDefaultValues();
            _User = clsUser.FindUser(_UserID);
            if (_User == null)
            {
                MessageBox.Show("Loading User has Failed","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            ctrlUserInformationCard1.LoadUserInfo(_UserID);
            
        }

        void ChangePasswordChar(TextBox textBox1)
        {
            textBox1.UseSystemPasswordChar = (textBox1.UseSystemPasswordChar) ? false : true;
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Field are Not Valid!. Hover the mouse over the error icons to see the message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            if (errorProvider1.GetError(txtNewPassword) != "" || errorProvider1.GetError(txtConfirmPassword) != "")
            {
                MessageBox.Show("Some Field are Empty!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                
                MessageBox.Show("Password Updated Successfully", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowPasswordsDefaultValues();
            }
            else
            {
                MessageBox.Show("Password Changing has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


        bool ValidateEmptyTextBox(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "This field can not be blank");
                return false;
            }

            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmptyTextBox(txtNewPassword))
                return;


            if (txtNewPassword.Text == _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New password must be different from the current one");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
            }
            

        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmptyTextBox(txtConfirmPassword))
                return;

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;    
                errorProvider1.SetError(txtConfirmPassword, "Password Conformation does not match password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmptyTextBox(txtCurrentPassword))
            {
                return;
            }
            if (txtCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is Wrong!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
                e.Cancel = false;
            }
        }

        private void pbNewPasswordPeek_Click(object sender, EventArgs e)
        {
            ChangePasswordChar(txtNewPassword);
        }

        private void pbConfirmPasswordPeek_Click(object sender, EventArgs e)
        {
            ChangePasswordChar(txtConfirmPassword);
        }

        private void pbCurrentPasswordPeek_Click(object sender, EventArgs e)
        {
            ChangePasswordChar(txtCurrentPassword);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
