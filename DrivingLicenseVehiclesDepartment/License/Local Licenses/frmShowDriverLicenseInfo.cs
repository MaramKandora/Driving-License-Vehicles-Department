using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PresentationLayer.License
{
    public partial class frmShowDriverLicenseInfo : Form
    {
        int _LicenseID;
        public frmShowDriverLicenseInfo(int licenseID)
        {
            InitializeComponent();
            this._LicenseID = licenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadLicenseInfo(_LicenseID); 
        }
    }
}
