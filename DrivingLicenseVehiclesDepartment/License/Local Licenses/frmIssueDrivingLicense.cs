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

namespace DVLD_PresentationLayer.License
{
    public partial class frmIssueDrivingLicense : Form
    {
        int _LDLAppID;
        clsLocalDrivingLicenseApplication _LDLAppInfo;
        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LDLAppID = LocalDrivingLicenseApplicationID;      
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LDLAppInfo =  clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(this._LDLAppID);

            if (_LDLAppInfo == null)
            {
                MessageBox.Show("Loading Issue License Form has Failed, LDLAppID is wrong","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!_LDLAppInfo.DoesPassedAllTests())
            {
                MessageBox.Show($"Loading Issue License Form has Failed, Person Did`t Pass all of the Tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return; 
            }

            int LicenseID = _LDLAppInfo.GetLicenseID();
            if ( LicenseID != -1)
            {
                MessageBox.Show($"Loading \'Issue License\' Form has Failed, License Already has been Issued, It`s ID ({LicenseID})",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfoUsingLDLAppID(_LDLAppID);

            lblLicenseFees.Text = clsLicenseClass.FindLicenseClassByID(_LDLAppInfo.LicenseClassID).Fees.ToString();

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            int NewLicenseID = _LDLAppInfo.IssueLicenseForFirstTime(clsGlobal.CurrentUser.UserID, txtNotes.Text.Trim());

            if (NewLicenseID != -1)
            {
              
                MessageBox.Show($"License Issued Successfully with LicenseID = {NewLicenseID}", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Issuance Driving License has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
