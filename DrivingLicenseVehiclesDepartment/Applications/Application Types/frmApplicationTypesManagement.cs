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

namespace DVLD_PresentationLayer.Application_Types
{
    public partial class frmApplicationTypesManagement : Form
    {
        DataView _dvAppTypes ;
        public frmApplicationTypesManagement()
        {
            InitializeComponent();
        }

        void RefreshAppTypes()
        {
            _dvAppTypes = clsApplicationType.GetAllApplicationTypes().DefaultView;
            dgvAppTypes.DataSource = _dvAppTypes;
            lblRecordsNum.Text = dgvAppTypes.Rows.Count.ToString(); 
           
        }
        private void frmApplicationTypesManagement_Load(object sender, EventArgs e)
        {
            RefreshAppTypes();

            if (dgvAppTypes.Rows.Count > 0)
            {
                dgvAppTypes.Columns[0].HeaderText = "ID";
                dgvAppTypes.Columns[0].Width = 120;

                dgvAppTypes.Columns[1].HeaderText = "Title";
                dgvAppTypes.Columns[1].Width = 370;

                dgvAppTypes.Columns[2].HeaderText = "Fees";
                dgvAppTypes.Columns[2].Width = 120;
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form EditAppType = new frmEditApplicationType((int)dgvAppTypes.CurrentRow.Cells[0].Value);
            EditAppType.ShowDialog();
            RefreshAppTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
