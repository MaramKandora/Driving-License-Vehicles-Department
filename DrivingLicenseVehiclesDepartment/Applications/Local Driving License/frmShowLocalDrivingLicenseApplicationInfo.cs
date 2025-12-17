using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PresentationLayer.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingLicenseApplicationInfo : Form
    {
        int _LDLAppID;
        public frmShowLocalDrivingLicenseApplicationInfo(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

      

        private void frmShowLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(_LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
