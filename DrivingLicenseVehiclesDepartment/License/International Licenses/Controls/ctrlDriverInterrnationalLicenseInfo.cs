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
using DVLD_PresentationLayer.Properties;

namespace DVLD_PresentationLayer.License.International_Licenses.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        int _InternationalLicenseID = -1;
        clsInternationalLicense _InternationalLicenseInfo = null;

        public int InternationalLicenseID { get { return _InternationalLicenseID; } }
        public clsInternationalLicense InternationalLicenseInfo { get { return _InternationalLicenseInfo; } }   
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        void ResetDefaultValues()
        {
            _InternationalLicenseID = -1;
            _InternationalLicenseInfo = null;
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblGender.Text = "???";
            lblApplicationID.Text = "???";
            lblInternationalLicenseID.Text = "???"; 
            lblLocalLicenseID.Text = "???";
            lblIsActive.Text = "???";
            lblIssueDate.Text = "???";
            lblNationalNo.Text = "???";
            lblPersonName.Text = "???";
            pbGender.Image = Resources.Man_32;
        }

        void LoadPersonImage()
        {
            
            string ImagePath = _InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbImage.ImageLocation = ImagePath;  
                }
                else
                {
                    MessageBox.Show($"Image in this path was not found: {ImagePath}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else
            {
                pbImage.Image = _InternationalLicenseInfo.DriverInfo.PersonInfo.Gender == clsPerson.enGender.Male ?
                    Resources.Male_512 : Resources.Female_512;
            }

        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicenseInfo = clsInternationalLicense.FindLicenseByInternationalLicenseID(InternationalLicenseID);
            if (_InternationalLicenseInfo == null)
            {
                ResetDefaultValues();
                return;
            }

            _InternationalLicenseID = InternationalLicenseID;
            lblDateOfBirth.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = _InternationalLicenseInfo.DriverID.ToString();
            lblExpirationDate.Text =_InternationalLicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy");
            lblGender.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.Gender.ToString();
            lblApplicationID.Text = _InternationalLicenseInfo.ApplicationID.ToString();
            lblInternationalLicenseID.Text = _InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalLicenseInfo.LocalLicenseID.ToString();
            lblIsActive.Text = (_InternationalLicenseInfo.IsActive) ? "Yes" : "No";
            lblIssueDate.Text = _InternationalLicenseInfo.IssueDate.ToString("dd/MMM/yyyy");
            lblNationalNo.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblPersonName.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.FullName;
            pbGender.Image = Resources.Man_32;
            LoadPersonImage();
        }
    }
}
