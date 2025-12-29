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
using DVLD_PresentationLayer.Applications;
using DVLD_PresentationLayer.Properties;

namespace DVLD_PresentationLayer.License
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        clsLicense _LicenseInfo;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        void ResetDefaultValues()
        {
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";   
            lblExpirationDate.Text = "???"; 
            lblGender.Text = "???";
            lblClassName.Text = "???";    
            lblIsActive.Text = "???";   
            lblIsDetained.Text = "???"; 
            lblIssueDate.Text = "???";  
            lblIssueReason.Text = "???";
            lblLicenseID.Text = "???";  
            lblNationalNo.Text = "???";
            lblNotes.Text = "???";  
            lblPersonName.Text = "???";
            pbGender.Image = Resources.Man_32;
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseInfo = clsLicense.FindLicenseByLicenseID(LicenseID);    

            if (_LicenseInfo != null)
            {
                lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
                lblDriverID.Text = _LicenseInfo.DriverID.ToString();    
                lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToString("dd/MM/yyyy");
                lblClassName.Text = _LicenseInfo.LicenseClassInfo.ClassName;
                lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
                lblIsDetained.Text = clsDetainedLicense.IsLicenseDetained(LicenseID)? "Yes" : "No" ;
                lblIssueDate.Text = _LicenseInfo.IssueDate.ToString("dd/MM/yyyy");
                lblIssueReason.Text = _LicenseInfo.GetIssueReasonText;
                lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
                lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
                lblNotes.Text = _LicenseInfo.Notes;
                lblPersonName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName;
                lblGender.Text = _LicenseInfo.DriverInfo.PersonInfo.Gender.ToString();
                pbGender.Image = (_LicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male) ?
                     Resources.Man_32 : Resources.Woman_32;

                if (_LicenseInfo.DriverInfo.PersonInfo.ImagePath != "")
                {
                    pbImage.Load(_LicenseInfo.DriverInfo.PersonInfo.ImagePath);
                }
                else
                {
                    pbImage.Image = (_LicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male) ?
                    Resources.Male_512 : Resources.Female_512;
                }

                    

            }
            else
            {
                MessageBox.Show("Loading License Info has failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
            }
        }
    }
}
