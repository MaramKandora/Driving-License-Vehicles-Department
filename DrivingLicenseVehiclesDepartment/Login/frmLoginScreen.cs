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

namespace DVLD_PresentationLayer.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        clsUser _User;

        string _UsersToRememberFile= @"E:\UsersToRemember_DVLD.txt";

        void SaveUserToRememberMeFile(clsUser User)
        {
            if (IsUserExistInRememberMeFile(User))
                return;

            string UserText= User.UserName + "#//#" + clsGlobal.EncryptText(User.Password, clsGlobal.EncryptionKey);

            try
            {
              
                File.AppendAllText(_UsersToRememberFile, UserText);
               
            }
            catch (IOException EX)
            {
                MessageBox.Show(EX.Message);    
            }


        }

      
        void DeleteUserFromRememberMeFile(clsUser User)
        {

            string UserText = User.UserName + "#//#" + clsGlobal.EncryptText(User.Password, clsGlobal.EncryptionKey);
            bool isUserTextExists = false;
            try
            {
                if (File.Exists(_UsersToRememberFile))
                {
                    string[] FileLines = File.ReadAllLines(_UsersToRememberFile);
                    string UpdatedFile = "";

                    for (int i = 0; i < FileLines.Length; i++)
                    {
                        if (FileLines[i] != UserText)
                        {
                             UpdatedFile += FileLines[i] + "\n";
                        }
                        else
                        {
                            isUserTextExists = true;
                        }
                    }

                    if (isUserTextExists)
                    {

                        File.WriteAllText(_UsersToRememberFile, UpdatedFile);

                    }
                   
                    

                }

                
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        bool IsUserExistInRememberMeFile(clsUser User)
        {

            try
            {
                if (File.Exists(_UsersToRememberFile))
                {
                    string[] FileLines = File.ReadAllLines(_UsersToRememberFile);
                    
                    foreach (string line in FileLines)
                    {
                        if (line.Contains(User.UserName))
                        {
                           return true;
                        }
                    }
                }

            }
            catch (IOException ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }


            return false;
        }

     
        void OnSignOut_Handler(int UserID)
        {
            clsUser User = clsUser.FindUser(UserID);

            if (IsUserExistInRememberMeFile(User))
            {
                txtUserName.Text = User.UserName;
                txtPassword.Text = User.Password;
                cbRemeberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                cbRemeberMe.Checked = false;
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          
            bool LoginSucceeded;

            if (txtUserName.Text != "")
            {
                _User = clsUser.FindUser(txtUserName.Text);

                if (_User != null)
                {
                    if (_User.Password.ToLower() == txtPassword.Text.ToLower())
                    {
                        if (_User.IsActive)
                            LoginSucceeded = true;
                        else
                        {
                            LoginSucceeded = false; 
                            MessageBox.Show("Your Account is Deactivated, Please Contact you Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        LoginSucceeded = false; 
                    }

                }
                else
                {
                    LoginSucceeded = false; 
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
                    SaveUserToRememberMeFile(_User);
                }
                else
                {
                    DeleteUserFromRememberMeFile(_User);
                }
               

                frmMain frmMainScreen = new frmMain(_User.UserID);
                frmMainScreen.ReturnUserOnSignOut += OnSignOut_Handler;
                frmMainScreen.ShowDialog();

              

            }
            else
            {
                MessageBox.Show("Invalid UserName\\Password", "Wrong Credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            //LoadUserLoginDataIfSetToBeRemembered(clsGlobal.CurrentUser);
        }
    }
}
