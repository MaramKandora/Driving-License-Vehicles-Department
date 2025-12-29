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
using DVLD_PresentationLayer.Application_Types;
using DVLD_PresentationLayer.Applications;
using DVLD_PresentationLayer.Drivers;
using DVLD_PresentationLayer.Global_Classes;
using DVLD_PresentationLayer.Tests;
using DVLD_PresentationLayer.Users;

namespace DVLD_PresentationLayer
{
    public partial class frmMain : Form
    {
        int _UserID;

        bool _CloseAllApp = true;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
       
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form PeopleManagement = new frmPeopleManagement();
            PeopleManagement.ShowDialog();
        }

        private void drivingLisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drivingLicensToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

         void _Logout()
        {
            clsGlobal.CurrentUser = null;
            _CloseAllApp = false;
            this.Close();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Logout();
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_CloseAllApp)
            {
                Application.Exit();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersManagement frmUsers = new frmUsersManagement();
            frmUsers.OnDeleteCurrentUser += OnDeleteCurrentUser_Handler;
            frmUsers.ShowDialog();  
        }

        void OnDeleteCurrentUser_Handler()
        {
            clsGlobal.ClearRememberMeFile();
            _Logout();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UserInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            UserInfo.ShowDialog();  

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);  
            ChangePassword.ShowDialog();    
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AppTypesManagement = new frmApplicationTypesManagement();
            AppTypesManagement.ShowDialog();    
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form TestTypesManagement = new frmTestTypesManagement();
            TestTypesManagement.ShowDialog();
        }

        private void loacalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNew_UpdateLDLApplication AddNewLDLApplication = new frmAddNew_UpdateLDLApplication();
            AddNewLDLApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmLDLApplications = new frmLocalDrivingLicenseApplicationsManagement();
            frmLDLApplications.ShowDialog();        
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriversList frmDrivers = new frmDriversList();
            frmDrivers.ShowDialog();
        }
    }
}
