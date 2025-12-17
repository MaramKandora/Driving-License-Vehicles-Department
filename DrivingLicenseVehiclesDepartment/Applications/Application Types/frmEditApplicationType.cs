using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_PresentationLayer.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        int _AppTypeID;
        clsApplicationType _AppType;
        public frmEditApplicationType(int ID)
        {
            InitializeComponent();
            _AppTypeID = ID; 
        }

       

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _AppType = clsApplicationType.FindApplicationType((clsApplicationType.enApplicationTypes)_AppTypeID);

            if (_AppType != null)
            {
                lblAppID.Text=_AppTypeID.ToString();
                txtAppTitle.Text = _AppType.ApplicationTypeTitle;
                txtAppFees.Text= _AppType.ApplicationFees.ToString();   
            }
            else
            {
                MessageBox.Show("Loading Application Type has Failed!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valid!. hover the mouse over the error icon(s) to see the message","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);   
                return;
            }

           _AppType.ApplicationTypeTitle = txtAppTitle.Text.Trim();
            _AppType.ApplicationFees = Convert.ToSingle(txtAppFees.Text.Trim());

            if (_AppType.Save())
            {
                MessageBox.Show("Application Typed Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updating Application Type has Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtAppFees_KeyPress(object sender, KeyPressEventArgs e)
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
