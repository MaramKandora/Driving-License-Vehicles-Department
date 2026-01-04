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
using DVLD_PresentationLayer.License;
using DVLD_PresentationLayer.License.International_Licenses;

namespace DVLD_PresentationLayer.Applications.Replacement_for_lost_or_damaged
{
    public partial class frmReplacementForLostOrDamaged : Form
    {
        int _NewLicenseID;
        public frmReplacementForLostOrDamaged()
        {
            InitializeComponent();
        }

        //enum enMode { ReplaceForLost, ReplaceForDamaged}
        //enMode _Mode;

        void ResetReplacementApplicationValues()
        {
            lblReplacedWithLicenseID.Text = "???";
            lblOldLicenseID.Text = "???";
            lblReplacementApplicationID.Text = "???";
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            rbLostLicense.Checked = true;
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.Replacement_Lost).ApplicationFees.ToString();

        }
        private void frmReplacementForLostOrDamaged_Load(object sender, EventArgs e)
        {
            btnReplace.Enabled = false;
            llblLicensesHistory.Enabled = false;
            llblNewLicenseInfo.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
            ResetReplacementApplicationValues();

        }

        

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelection(int obj)
        {
            int SelectedLicenseID = obj;

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID != -1)
            {
                llblLicensesHistory.Enabled = true;
                lblOldLicenseID.Text = SelectedLicenseID.ToString();


                if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive == false)
                {
                    MessageBox.Show($"Selected Local License in not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReplace.Enabled = false;
                    return;
                }


                btnReplace.Enabled = true;

            }
            else
            {
                btnReplace.Enabled = false;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID == -1)
            {
                MessageBox.Show("Select a valid Local License First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure do you want to Replace the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicenseInfo;
            if (rbDamagedLicense.Checked)
            {
                NewLicenseInfo = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(clsLicense.enReplacementMode.ForDamaged, clsGlobal.CurrentUser.UserID) ;
            }
            else
            {
                NewLicenseInfo = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(clsLicense.enReplacementMode.ForLost, clsGlobal.CurrentUser.UserID);
            }

            if (NewLicenseInfo != null)
            {
                MessageBox.Show($"License Replaced Successfully. New License ID = {NewLicenseInfo.LicenseID}", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _NewLicenseID = NewLicenseInfo.LicenseID;   
                lblReplacementApplicationID.Text = NewLicenseInfo.ApplicationID.ToString();
                lblReplacedWithLicenseID.Text = NewLicenseInfo.LicenseID.ToString();
                btnReplace.Enabled = false;
                llblNewLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);

            }
            else
            {
                MessageBox.Show($"License Replacement has Failed", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblHeader.Text = "Replacement For Lost License";
                this.Text = lblHeader.Text;
                lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.Replacement_Lost).ApplicationFees.ToString();
            }
            else
            {
                
                lblHeader.Text = "Replacement For Damaged License";
                this.Text = lblHeader.Text;
                lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.Replacement_Damaged).ApplicationFees.ToString();
            }
        }

        private void llblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory LicensesHistory =
                new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
        }

        private void llblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
    }
    
}
