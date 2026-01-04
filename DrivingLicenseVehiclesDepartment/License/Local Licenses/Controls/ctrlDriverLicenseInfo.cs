using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_PresentationLayer.Applications;
using DVLD_PresentationLayer.Properties;

namespace DVLD_PresentationLayer.License
{
    public partial class ctrlLicenseInfo : UserControl
    {
        int _LicenseID = -1;
        clsLicense _LicenseInfo = null;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID { get {  return _LicenseID; } } 
        public clsLicense LicenseInfo { get { return _LicenseInfo; } }

        void ResetDefaultValues()
        {
            _LicenseID = -1;
            _LicenseInfo = null;    
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


        void LoadPersonImage()
        {
            pbImage.Image = (_LicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male) ?
               Resources.Male_512 : Resources.Female_512;

            string ImagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this Image :" + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
        public void LoadLicenseInfo(int LicenseID)
        {
           
            _LicenseInfo = clsLicense.FindLicenseByLicenseID(LicenseID);    

            if (_LicenseInfo != null)
            {
                _LicenseID = LicenseID;
                lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
                lblDriverID.Text = _LicenseInfo.DriverID.ToString();    
                lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy");
                lblClassName.Text = _LicenseInfo.LicenseClassInfo.ClassName;
                lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
                lblIsDetained.Text = _LicenseInfo.IsDetained ? "Yes" : "No" ;
                lblIssueDate.Text = _LicenseInfo.IssueDate.ToString("dd/MMM/yyyy");
                lblIssueReason.Text = _LicenseInfo.GetIssueReasonText;
                lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
                lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
                lblNotes.Text = (_LicenseInfo.Notes == "") ? "No Notes" : _LicenseInfo.Notes;
                lblPersonName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName;
                lblGender.Text = _LicenseInfo.DriverInfo.PersonInfo.Gender.ToString();
                pbGender.Image = (_LicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male) ?
                     Resources.Man_32 : Resources.Woman_32;

                LoadPersonImage();

            }
            else
            {
                MessageBox.Show($"Could not Find License with ID \'{LicenseID}\'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
            }
        }
    }
}
