using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_PresentationLayer.Users;

namespace DVLD_PresentationLayer
{
    public partial class frmMain : Form
    {
        int _UserID; 
        
        public event Action<int> ReturnUserOnSignOut;
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

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnUserOnSignOut?.Invoke(_UserID);
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReturnUserOnSignOut?.Invoke(_UserID);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUsers = new frmUsersManagement();
            frmUsers.ShowDialog();  
        }
    }
}
