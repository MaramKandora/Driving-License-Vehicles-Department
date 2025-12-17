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
using DVLD_PresentationLayer.Tests.Test_Types;

namespace DVLD_PresentationLayer.Tests
{
    public partial class frmTestTypesManagement : Form
    {
        DataView _dvTestTypes;
        public frmTestTypesManagement()
        {
            InitializeComponent();
        }

        void RefreshTestTypes()
        {
            _dvTestTypes = clsTestType.GetAllTestTypes().DefaultView;
            dgvTestTypesList.DataSource = _dvTestTypes;
            lblRecordsNum.Text = dgvTestTypesList.Rows.Count.ToString();

        }
      
      

        private void frmTestTypesManagement_Load(object sender, EventArgs e)
        {
            RefreshTestTypes();

            if (dgvTestTypesList.Rows.Count > 0)
            {
                dgvTestTypesList.Columns[0].HeaderText = "ID";
                dgvTestTypesList.Columns[0].Width = 120;

                dgvTestTypesList.Columns[1].HeaderText = "Title";
                dgvTestTypesList.Columns[1].Width = 150;

                dgvTestTypesList.Columns[2].HeaderText = "Description";
                dgvTestTypesList.Columns[2].Width = 435;

                dgvTestTypesList.Columns[3].HeaderText = "Fees";
                dgvTestTypesList.Columns[3].Width = 120;
            }
        }
      

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form EditTestType = new frmEditTestType((clsTestType.enTestType)dgvTestTypesList.CurrentRow.Cells[0].Value);
            EditTestType.ShowDialog();
            RefreshTestTypes();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
