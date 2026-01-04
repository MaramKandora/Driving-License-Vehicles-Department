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

namespace DVLD_PresentationLayer.License.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {

        public event Action<int> OnLicenseSelection;

        public int SelectedLicenseID { get { return ctrlLicenseInfo1.LicenseID; } }

        public clsLicense SelectedLicenseInfo { get { return ctrlLicenseInfo1.LicenseInfo; } }
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        bool _FilterEnabled;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        void LicenseSelected(int LicenseID)
        {

            Action<int> handler = OnLicenseSelection;
            if (handler != null)
            {
                handler.Invoke(LicenseID);
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilter.Text = LicenseID.ToString();
            ctrlLicenseInfo1.LoadLicenseInfo(LicenseID);
            if (FilterEnabled)
            {
                LicenseSelected(LicenseID);

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadLicenseInfo(Convert.ToInt32(txtFilter.Text.Trim()));
           
                LicenseSelected(ctrlLicenseInfo1.LicenseID);
            
        }

        public void FilterFocus()
        {
            txtFilter.Select();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }

        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {

                errorProvider1.SetError(txtFilter, "This field is required!");
            }
            else
            {

                errorProvider1.SetError(txtFilter, null);
            }
        }
    }
}
