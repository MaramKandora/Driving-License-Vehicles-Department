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
using DVLD_PresentationLayer.License.International_Licenses.Controls;

namespace DVLD_PresentationLayer.Applications.Renew_License
{
    public partial class frmRenewLicense : Form
    {
        int _NewLicenseID;
        public frmRenewLicense()
        {
            InitializeComponent();
        }

        void ResetRenewApplicationValues()
        {
            lblRenewLicenseApplicationID.Text = "???";
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.RenewLicense).ApplicationFees.ToString();
            lblLicenseFees.Text = "$$$";
            lblTotalFees.Text = "$$$";
            lblRenewedLicenseID.Text = "???";
            lblOldLicenseID.Text = "???";
            lblExpirationDate.Text = "???";
        }
        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            btnRenew.Enabled = false;
            llblLicensesHistory.Enabled = false;
            llblNewLicenseInfo.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
            ResetRenewApplicationValues();

        }

       
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelection(int obj)
        {
            int SelectedLicenseID = obj;

            if (SelectedLicenseID != -1)
            {
                
                llblLicensesHistory.Enabled = true;
                lblOldLicenseID.Text = SelectedLicenseID.ToString();
                lblLicenseFees.Text = clsLicenseClass.FindLicenseClassByID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID).Fees.ToString();
                lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();

                if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsExpired == false) 
                {
                    MessageBox.Show($"Selected Local License is not Expired yet, It will Expire on {ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy")} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRenew.Enabled = false;   
                    return;
                }

                if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive == false)
                {
                    MessageBox.Show($"Selected Local License in not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRenew.Enabled = false;
                    return ;
                }


                btnRenew.Enabled = true;
                
            }
            else
            {
                btnRenew.Enabled = false;
            }

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID == -1)
            {
                MessageBox.Show("Select a valid Local License First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure do you want to renew the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicenseInfo = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(clsGlobal.CurrentUser.UserID, txtNotes.Text.Trim());
            if (NewLicenseInfo != null)
            {
                MessageBox.Show($"License Renewed Successfully. New License ID = {NewLicenseInfo.LicenseID}", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _NewLicenseID = NewLicenseInfo.LicenseID;
                lblRenewLicenseApplicationID.Text =NewLicenseInfo.ApplicationID.ToString();
                lblExpirationDate.Text = NewLicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy");
                lblRenewedLicenseID.Text = NewLicenseInfo.LicenseID.ToString();
                btnRenew.Enabled = false;
                llblNewLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
            }
            else
            {
                MessageBox.Show($"Renewing License had Failed", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void llblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory LicensesHistory = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
        }

        private void llblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
    }
}
