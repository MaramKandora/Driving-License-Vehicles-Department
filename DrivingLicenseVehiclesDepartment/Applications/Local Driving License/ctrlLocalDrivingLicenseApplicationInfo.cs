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
using DVLD_PresentationLayer.License;

namespace DVLD_PresentationLayer.Applications.Controls
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LDLAppInfo;

        int _LDLAppID = -1;

        int _LicenseID = -1;
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }


        public void LoadLocalDrivingLicenseApplicationInfoUsingLDLAppID(int LDLAppID)
        {
             _LDLAppInfo = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(LDLAppID);
            if (_LDLAppInfo != null)
            {
                byte PassedTests = clsTest.GetNumberOfPassedTests(LDLAppID);
                ctrlApplicationBasicInfo1.LoadApplicationInfo(_LDLAppInfo.ApplicationID);

                _LicenseID = clsLicense.GetLicenseIDUsingApplicationID(_LDLAppInfo.ApplicationID);
                _LDLAppID = _LDLAppInfo.LDLApplicationID;
                llblShowLicenseInfo.Enabled = true;
                lblLDLAppID.Text = _LDLAppInfo.LDLApplicationID.ToString();
                lblLicenseClass.Text = _LDLAppInfo.LicenseClassInfo.ClassName;
                lblPassedTest.Text = $"{PassedTests}\\3";

                if (PassedTests != 3)
                    llblShowLicenseInfo.Enabled = false;
                else
                    llblShowLicenseInfo.Enabled = true;
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
            frmShowDriverLicenseInfo LicenseInfo = new frmShowDriverLicenseInfo(_LicenseID);
            LicenseInfo.ShowDialog();   
        }
    }
}
