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
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelection(int obj)
        {
            int SelectedLicenseID = obj;

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID != -1)
            {
                llblLicensesHistory.Enabled = true;
                lblLicenseID.Text = SelectedLicenseID.ToString();


                //if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive == false)
                //{
                //    MessageBox.Show($"Selected License is not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    btnDetain.Enabled = false;
                //    return;
                //}

                if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
                {
                    MessageBox.Show($"Selected License is Already Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDetain.Enabled = false;
                    return;
                }

                txtFineFees.Focus();
                btnDetain.Enabled = true;

            }
            else
            {
                btnDetain.Enabled = false;
            }
        }

        void ResetDetainDefaultValues()
        {
            lblLicenseID.Text = "???";
            lblDetainID.Text = "???";
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            llblLicensesHistory.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
            ResetDetainDefaultValues();
          
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseID == -1)
            {
                MessageBox.Show("Select a valid Local License First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are Not Valid, hover mouse over the error icon to see the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure do you want to Detain Selected License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.No)
            {
                return;
            }


            int DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text.Trim()), clsGlobal.CurrentUser.UserID);
            if (DetainID != -1)
            {
                MessageBox.Show($"License Detention Completed Successfully. Detain ID = {DetainID}", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblDetainID.Text = DetainID.ToString();   
                btnDetain.Enabled = false;   
                txtFineFees.Enabled =false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);

            }
            else
            {
                MessageBox.Show($"License Detention has Failed", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                errorProvider1.SetError(txtFineFees, "Please Enter Fine Amount");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void llblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory LicensesHistory =
                          new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            LicensesHistory.ShowDialog();
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
        }
    }
}
