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

namespace DVLD_PresentationLayer.Applications.Controls
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LDLAppInfo;

        int _LDLAppID = -1;
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }


        public void LoadLocalDrivingLicenseApplicationInfo(int LDLAppID)
        {
             _LDLAppInfo = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(LDLAppID);
            if (_LDLAppInfo != null)
            {
                ctrlApplicationBasicInfo1.LoadApplicationInfo(_LDLAppInfo.ApplicationID);

                _LDLAppID = _LDLAppInfo.LDLApplicationID;
                llblShowLicenseInfo.Enabled = true;
                lblLDLAppID.Text = _LDLAppInfo.LDLApplicationID.ToString();
                lblLicenseClass.Text = _LDLAppInfo.LicenseClassInfo.ClassName;
                lblPassedTest.Text = $"{clsLocalDrivingLicenseApplication.GetNumberOfPassedTests(LDLAppID)}\\3";
            }
            else
            {
                MessageBox.Show("Loading Local Driving License Application Info has failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
            }
        }


        public void LoadLocalDrivingLicenseApplicationInfoUsingBaseApplicationID(int LDLAppID)
        {
           // ToDo
        }

        void ResetDefaultValues()
        {
            lblLDLAppID.Text = "???";
            lblLicenseClass.Text = "???";
            lblPassedTest.Text = "???";
            llblShowLicenseInfo.Enabled = false;    
        }
        private void ctrlLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // TODO: finish this after implementing clsLicense and clsTest
        }
    }
}
