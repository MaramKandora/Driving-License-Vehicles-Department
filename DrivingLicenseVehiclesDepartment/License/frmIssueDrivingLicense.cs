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
            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfoUsingLDLAppID(_LDLAppID);
            _LDLAppInfo =  clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(this._LDLAppID);

            if (_LDLAppInfo == null)
            {
                MessageBox.Show("Loading Issue License Form has Failed, LDLAppID is wrong","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (_LDLAppInfo.enApplicationStatusID != clsApplication.enApplicationStatus.New)
            {
                MessageBox.Show($"Loading Issue License Form has Failed, Selected Local Driving License Application \'{_LDLAppInfo.enApplicationStatusID.ToString()}\'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            clsLicense License = clsLicense.FindLicenseByApplicationID(_LDLAppInfo.ApplicationID);

            if (License != null)
            {
                MessageBox.Show($"Loading \'Issue License\' Form has Failed, License Already has been Issued, It`s ID ({License.LicenseID})",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense License = new clsLicense();
            clsDriver Driver = clsDriver.FindDriverUsingPersonID(_LDLAppInfo.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = _LDLAppInfo.ApplicantPersonID;
                Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Driver.Save())
                {
                    MessageBox.Show("Issuance Driving License has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            License.ApplicationID = _LDLAppInfo.ApplicationID;
            License.DriverID = Driver.DriverID;
            License.LicenseClassID = _LDLAppInfo.LicenseClassID;
            License.Notes = txtNotes.Text;
            License.PaidFees = _LDLAppInfo.LicenseClassInfo.Fees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (License.Save())
            {
                _LDLAppInfo.SetCompleted();
                MessageBox.Show($"License Issued Successfully with LicenseID = {License.LicenseID}", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
