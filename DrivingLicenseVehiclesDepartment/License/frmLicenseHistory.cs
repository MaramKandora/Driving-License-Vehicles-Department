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

namespace DVLD_PresentationLayer.License
{
    public partial class frmLicenseHistory : Form
    {
        int _PersonID;
        clsPerson _PersonInfo;
        DataView _dvLocalLicensesList;
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;   
        }

        void RefreshLocalLicensesList()
        {
            _dvLocalLicensesList = clsLicense.GetAllLocalLicensesForPerson(_PersonID).DefaultView;
            dgvLocalLicenses.DataSource = _dvLocalLicensesList;
            lblRecordsNum.Text = dgvLocalLicenses.RowCount.ToString();

            if (dgvLocalLicenses.RowCount > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "License ID";
                dgvLocalLicenses.Columns[0].Width = 150;

                dgvLocalLicenses.Columns[1].HeaderText = "Application ID";
                dgvLocalLicenses.Columns[1].Width = 150;

                dgvLocalLicenses.Columns[2].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[2].Width = 200;

                dgvLocalLicenses.Columns[3].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[3].Width = 200;

                dgvLocalLicenses.Columns[4].HeaderText = "Is Active";
                dgvLocalLicenses.Columns[4].Width = 100;
            }
            
        }
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {


            if (!ctrlPersonCard1.LoadPersonInfo(_PersonID))
            {
                this.Close();
            }

            RefreshLocalLicensesList();
        }
    }
}
