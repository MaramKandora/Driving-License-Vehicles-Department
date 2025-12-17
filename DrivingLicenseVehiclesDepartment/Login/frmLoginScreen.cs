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
using System.IO;
using Microsoft.SqlServer.Server;
using DVLD_PresentationLayer.Global_Classes;

namespace DVLD_PresentationLayer.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        clsUser _User;


        private void btnLogin_Click(object sender, EventArgs e)
        {
          
            bool LoginSucceeded;


            _User = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (_User != null)
            {
                if (_User.IsActive)
                    LoginSucceeded = true;
                else
                {
                    LoginSucceeded = false;
                    txtUserName.Focus();
                    MessageBox.Show("Your Account is been Deactivated, Please Contact you Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                LoginSucceeded = false;
            }
            

            if (LoginSucceeded)
            {
                 clsGlobal.CurrentUser = _User;
                
                if (cbRemeberMe.Checked)
                {
                    clsGlobal.RememberUserCredentials(_User);
                }
                else
                {
                    clsGlobal.ClearRememberMeFile();
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }

                this.Hide();

                frmMain frmMainScreen = new frmMain(_User.UserID);
                frmMainScreen.ShowDialog();


                this.Show();
              

            }
            else
            {
                MessageBox.Show("Invalid UserName\\Password", "Wrong Credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.LoadStoredCredentials(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                cbRemeberMe.Checked = true; 
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                cbRemeberMe.Checked = false;
            }

            
        }

        void MainFormClosed_Handler(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar) && (e.KeyChar != '_' && e.KeyChar != '-' && e.KeyChar != '@')) 
            {
                e.Handled = true;
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = (txtPassword.UseSystemPasswordChar) ? false : true;
        }



        private void textbox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;  
            }

            if ((TextBox)sender == txtUserName && e.KeyChar == (char)Keys.Enter) 
            {
                txtPassword.Focus();
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

   

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }
    }
}
