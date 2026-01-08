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

namespace DVLD_PresentationLayer.Applications.Detain_And_Release_License
{
    public partial class frmReleaseLicenseApplication : Form
    {
        clsDetainedLicense _DetainedLicense;
        public frmReleaseLicenseApplication()
        {
            InitializeComponent();
            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
        }

        public frmReleaseLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }
        void ResetDetainDefaultValues()
        {
            lblLicenseID.Text = "???";
            lblDetainID.Text = "???";
            lblCreatedByUser.Text = "???";
            lblDetainDate.Text = "???";
            lblApplicationFees.Text = "???";
            lblFineFees.Text = "???";
            lblTotalFees.Text = "???";
            lblApplicationID.Text = "???";

        }
        private void frmReleaseLicenseApplication_Load(object sender, EventArgs e)
        {
          llblLicensesHistory.Enabled = false;  
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelection(int obj)
        {
            int SelectedLicenseID = obj;

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID != -1)
            {
                llblLicensesHistory.Enabled = true;
                lblLicenseID.Text = SelectedLicenseID.ToString();
              

                clsDetainedLicense DetainedLicense = clsDetainedLicense.FindDetainedLicenseByLicenseID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);

                if (DetainedLicense == null)
                {
                    MessageBox.Show($"Selected License is Not Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRelease.Enabled = false;
                    return;
                }

                lblDetainID.Text = DetainedLicense.DetainID.ToString();
                lblDetainDate.Text = DetainedLicense.DetainDate.ToString("dd/MMM/yyyy");
                lblLicenseID.Text = DetainedLicense.LicenseID.ToString();
                lblCreatedByUser.Text = DetainedLicense.CreatedByUserInfo.UserName;
                lblFineFees.Text = DetainedLicense.FineFees.ToString();
                lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReleaseDetainedL).ApplicationFees.ToString();
                lblTotalFees.Text = (Convert.ToSingle(lblFineFees.Text) + Convert.ToSingle(lblApplicationFees.Text)).ToString();
                
                btnRelease.Enabled = true;

            }
            else
            {
                btnRelease.Enabled = false;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID == -1)
            {
                MessageBox.Show("Select a valid Local License First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure do you want to Release Selected License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.No)
            {
                return;
            }

            clsDetainedLicense DetainedLicense = clsDetainedLicense.FindDetainedLicenseByLicenseID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);


            if (DetainedLicense != null)
            {
                if (DetainedLicense.Release(clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show($"License Released Successfully.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblApplicationID.Text = DetainedLicense.ReleaseApplicationID.ToString();
                    btnRelease.Enabled = false;
                    ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                    ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
                }
            }
            else
            {
                MessageBox.Show($"Selected License is not Released", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void llblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory LicensesHistory =
                          new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
