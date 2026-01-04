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
using DVLD_PresentationLayer.Properties;
using static DVLD_BusinessLayer.clsPerson;

namespace DVLD_PresentationLayer.License.International_Licenses.Controls
{
    public partial class ctrlInternationalApplicationInfo : UserControl
    {
        int _InternationalLicenseID;
        clsInternationalLicense _InternationalLicenseInfo;

        public ctrlInternationalApplicationInfo()
        {
            InitializeComponent();
        }

        public void ResetDefaultValues()
        {
            lblIntrnationalLicenseID.Text = "???";
            lblInternationalApplicationID.Text = "???";
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.NewInternationalL).ApplicationFees.ToString();
            lblLocalLicenseID.Text = "???";
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MMM/yyyy");
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;  
          
        }

        public bool SetLocalLicenseID(int LocalLicenseID)
        {
            if (clsLicense.IsLicenseExistByLicenseID(LocalLicenseID))
            {
                lblLocalLicenseID.Text = LocalLicenseID.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicenseInfo = clsInternationalLicense.FindLicenseByInternationalLicenseID(InternationalLicenseID);
            if (_InternationalLicenseInfo == null)
            {
                MessageBox.Show("Loading Application Type has Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }
            _InternationalLicenseID = InternationalLicenseID;
            lblIntrnationalLicenseID.Text = _InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblApplicationDate.Text = _InternationalLicenseInfo.ApplicationInfo.ApplicationDate.ToString();
            lblIssueDate.Text = _InternationalLicenseInfo.IssueDate.ToString(); 
            lblFees.Text = _InternationalLicenseInfo.ApplicationInfo.Fees.ToString();   
            lblInternationalApplicationID.Text = _InternationalLicenseInfo.ApplicationInfo.ApplicationID.ToString();    
            lblLocalLicenseID.Text = _InternationalLicenseInfo.LocalLicenseID.ToString(); 
            lblExpirationDate.Text =_InternationalLicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy");
            lblCreatedByUser.Text = _InternationalLicenseInfo.CreatedByUserInfo.UserName;
           

        }

        private void ctrlInternationalApplicationInfo_Load(object sender, EventArgs e)
        {
           
        }
    }
}
