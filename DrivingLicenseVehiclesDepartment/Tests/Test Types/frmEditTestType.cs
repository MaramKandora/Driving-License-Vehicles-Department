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

namespace DVLD_PresentationLayer.Tests.Test_Types
{
    public partial class frmEditTestType : Form
    {

        clsTestType.enTestType _enTestType;
        clsTestType _TestType;
        public frmEditTestType(clsTestType.enTestType enTestType1)
        {
            InitializeComponent();
            _enTestType = enTestType1;
        }



        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.FindTestType(_enTestType);

            if (_TestType != null)
            {
                lblTestTypeID.Text = _TestType.enTestType1.ToString();
                txtTestTypeTitle.Text = _TestType.TestTypeTitle;
                txtTestTypeDescription.Text = _TestType.TestTypeDescription;
                txtTestTypeFees.Text = _TestType.TestFees.ToString();
            }
            else
            {
                MessageBox.Show("Loading Test Type has Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valid!. hover the mouse over the error icon(s) to see the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestTypeTitle = txtTestTypeTitle.Text.Trim();
            _TestType.TestTypeDescription = txtTestTypeDescription.Text.Trim(); 
            _TestType.TestFees = Convert.ToSingle(txtTestTypeFees.Text.Trim());

            if (_TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updating Test Type has Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void textbox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "This Field Can not be blank");
            }
            else
            {
                errorProvider1.SetError((TextBox)sender, null);
            }

        }

        private void txtTestFees_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
