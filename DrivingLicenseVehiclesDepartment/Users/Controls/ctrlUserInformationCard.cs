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

namespace DVLD_PresentationLayer.Users.Controls
{
    public partial class ctrlUserInformationCard : UserControl
    {
        int _UserID;
        clsUser _User;
        
        public ctrlUserInformationCard()
        {
            InitializeComponent();
        }

        public int UserID
        {
            get {  return _UserID; }    
        }

        void ShowDefaultUserInfo()
        {
            ctrlPersonCard1.ShowDefaultPersonInfo();
            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }
      
        void FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }

        public void LoadUserInfo(int UserID)
        {

             _User=clsUser.FindUser(UserID);  

            if (_User != null)
            {
                FillUserInfo();
            }
            else
            {
                MessageBox.Show("Loading User info has Failed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ShowDefaultUserInfo();
            }
           
        }

    }
}
