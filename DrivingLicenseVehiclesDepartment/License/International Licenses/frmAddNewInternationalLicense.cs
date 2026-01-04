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

namespace DVLD_PresentationLayer.License.International_Licenses
{
    public partial class frmAddNewInternationalLicense : Form
    {
        clsLicense _SelectedLocalLicense = null;
        int _NewInternationalLicenseID;
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = true;
            llblLicensesHistory.Enabled = false;
            llblLicenseInfo.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
            ctrlInternationalApplicationInfo1.ResetDefaultValues();
        }

         bool CheckHasInternationalLicenseConstraint()
        {
            int InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseForDriver((_SelectedLocalLicense).DriverID);
            if (InternationalLicenseID != -1)
            {
                MessageBox.Show($"Driver Already has an Active International License with ID = {InternationalLicenseID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool CheckActiveLocalLicenseConstraint()
        {
            if (_SelectedLocalLicense.IsActive == false)
            {
                MessageBox.Show($"Selected Local License in not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        bool CheckLocalLicenseExpirationConstraint()
        {
            if (_SelectedLocalLicense.IsExpired)
            {
                MessageBox.Show($"Selected Local License in Expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;    
        }

        bool CheckOrdinaryLocalLicenseConstraint()
        {
            if (_SelectedLocalLicense.LicenseClassInfo.enLicenseClassID != clsLicenseClass.enLicenseClasses.Ordinary)
            {
                MessageBox.Show($"international License Issuance is Allowed for Local Ordinary Class Licenses Only ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
      
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID == -1)
            {
                MessageBox.Show("Select a valid Local License First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure do you want to issue the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.No) 
            {
                return;
            }

            _NewInternationalLicenseID = _SelectedLocalLicense.IssueInternationalLicense(clsGlobal.CurrentUser.UserID);
            if (_NewInternationalLicenseID != -1)
            {
                MessageBox.Show($"International License Issued Successfully with ID = {_NewInternationalLicenseID}", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                llblLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                ctrlInternationalApplicationInfo1.LoadInternationalLicenseInfo(_NewInternationalLicenseID);
            }
            else
            {
                MessageBox.Show($"International License Issuance had Failed", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory LicensesHistory = new frmShowPersonLicenseHistory(_SelectedLocalLicense.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLocalLicense.LicenseID);

        }

        private void llblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_NewInternationalLicenseID);
            frm.ShowDialog();   
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelection(int obj)
        {
            int SelectedLicenseID = obj;

            if (SelectedLicenseID != -1)
            {
                _SelectedLocalLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo;
                llblLicensesHistory.Enabled = true;
                ctrlInternationalApplicationInfo1.SetLocalLicenseID(SelectedLicenseID);

                if (CheckOrdinaryLocalLicenseConstraint() && CheckActiveLocalLicenseConstraint() && CheckLocalLicenseExpirationConstraint() && CheckHasInternationalLicenseConstraint())
                {
                    btnIssue.Enabled = true;
                }
                else
                {
                    btnIssue.Enabled = false;
                }
            }
            else
            {
                btnIssue.Enabled= false;    
            }
        }
    }
}
