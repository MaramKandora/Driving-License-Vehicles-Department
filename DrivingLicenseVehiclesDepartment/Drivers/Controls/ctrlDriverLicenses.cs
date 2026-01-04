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
using DVLD_PresentationLayer.License;
using DVLD_PresentationLayer.License.International_Licenses;

namespace DVLD_PresentationLayer.Drivers.Controls
{
    
    public partial class ctrlDriverLicenses : UserControl
    {
        int _DriverID=-1;
        clsDriver _DriverInfo=null;

        public int DriverID { get { return _DriverID; }}

       public clsDriver DriverInfo { get { return _DriverInfo; }}   

        DataView _dvLocalLicensesList;

        DataView _dvInternationalLicensesList;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;   
            _DriverInfo = clsDriver.FindDriverUsingDriverID(DriverID);
            if (_DriverInfo == null)
            {
                MessageBox.Show("Loading Driver`s Licenses had Failed, Driver ID is Wrong ");
                return;
            }

            LoadLocalLicensesList();
            LoadInternationalLicensesList();
        }


        public void LoadInfoUsingPersonID(int PersonID)
        {
            
            _DriverInfo = clsDriver.FindDriverUsingPersonID(PersonID);
            if (_DriverInfo == null)
            {
                MessageBox.Show("Loading Driver`s Licenses had Failed, Person ID is Wrong or he is not a Driver. Person ID =" + PersonID);
                return;
            }
            _DriverID = _DriverInfo.DriverID;   
            LoadLocalLicensesList();
            LoadInternationalLicensesList();
        }

        void LoadInternationalLicensesList()
        {
            _dvInternationalLicensesList = clsInternationalLicense.GetAllInternationalLicensesForDriver(DriverID).DefaultView;
            dgvInternationalLicenses.DataSource = _dvInternationalLicensesList;
            lblRecordsNum.Text = dgvLocalLicenses.RowCount.ToString();

            if (dgvInternationalLicenses.RowCount > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 200;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 200;

                dgvInternationalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[2].Width = 200;

                dgvInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[3].Width = 200;

                dgvInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[4].Width = 200;

                dgvInternationalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[5].Width = 150;
            }
        }

        public void Clear()
        {
            if (dgvInternationalLicenses.RowCount > 0)
                _dvInternationalLicensesList.Table.Clear();
            if(dgvLocalLicenses.RowCount>0)
            _dvLocalLicensesList.Table.Clear();
        }
        void LoadLocalLicensesList()
        {
            _dvLocalLicensesList = clsLicense.GetAllLocalLicensesForDriver(_DriverID).DefaultView;
            dgvLocalLicenses.DataSource = _dvLocalLicensesList;
            lblRecordsNum.Text = dgvLocalLicenses.RowCount.ToString();

            if (dgvLocalLicenses.RowCount > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "License ID";
                dgvLocalLicenses.Columns[0].Width = 200;

                dgvLocalLicenses.Columns[1].HeaderText = "Application ID";
                dgvLocalLicenses.Columns[1].Width = 200;

                dgvLocalLicenses.Columns[2].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[2].Width = 200;

                dgvLocalLicenses.Columns[3].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[3].Width = 200;

                dgvLocalLicenses.Columns[4].HeaderText = "Is Active";
                dgvLocalLicenses.Columns[4].Width = 150;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tpLocalLicenses)
            {
                lblRecordsNum.Text = dgvLocalLicenses.RowCount.ToString();
            }
            else
            {
                lblRecordsNum.Text = dgvInternationalLicenses.RowCount.ToString();

            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tpLocalLicenses)
            {
                frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells["LicenseID"].Value);
                frm.ShowDialog();
                LoadLocalLicensesList();

            }
            else if (tabControl1.SelectedTab == tpInternationalLicenses)
            {
                frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells["InternationalLicenseID"].Value);
                frm.ShowDialog();
            }
        }
    }
}
