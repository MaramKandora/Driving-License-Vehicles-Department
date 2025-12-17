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

namespace DVLD_PresentationLayer.Applications
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        clsApplication _ApplicationInfo = null;

        int _ApplicationID = -1; 
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }



        public void LoadApplicationInfo(int ApplicationID)
        {
             _ApplicationInfo = clsApplication.FindBaseApplicationByID(ApplicationID); 

            if (_ApplicationInfo != null)
            {
                _ApplicationID= _ApplicationInfo.ApplicationID; 
                lblID.Text = _ApplicationInfo.ApplicationID.ToString();
                lblFees.Text = _ApplicationInfo.Fees.ToString();
                lblDate.Text = _ApplicationInfo.ApplicationDate.ToShortDateString();
                lblApplicant.Text = _ApplicationInfo.ApplicantPersonInfo.FullName;
                lblLastStatusDate.Text = _ApplicationInfo.LastStatusDate.ToShortDateString();
                lblStatus.Text = _ApplicationInfo.enApplicationStatus1.ToString();
                lblType.Text = _ApplicationInfo.ApplicationTypeInfo.ApplicationTypeTitle;
                lblUserCreatedBy.Text = _ApplicationInfo.CreatedByUserInfo.UserName;
            }
            else
            {
                MessageBox.Show("Loading Application Info has failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
            }
        }


        void ResetDefaultValues()
        {
            _ApplicationID = -1;
            lblID.Text = "???";
            lblApplicant.Text = "???";
            lblDate.Text = "???";   
            lblFees.Text = "???";
            lblLastStatusDate.Text = "???"; 
            lblStatus.Text = "???"; 
            lblType.Text = "???";
            lblUserCreatedBy.Text = "???";      
        }
      
        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInformation PersonInfo = new frmPersonInformation(_ApplicationInfo.ApplicantPersonID);
            PersonInfo.ShowDialog();

            //refresh
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
