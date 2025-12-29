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

namespace DVLD_PresentationLayer.Users
{
    public partial class frmAddNew_UpdateUser : Form
    {

        int _UserID;
        clsUser _User = null;
        public frmAddNew_UpdateUser()
        {
           
            InitializeComponent();
            _Mode = enMode.AddNew;
            this._UserID = -1;
            _User = new clsUser();

        }
        public frmAddNew_UpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            this._UserID = UserID;
        }
        enum enMode { AddNew, Update}
        enMode _Mode;
        void ShowSelectedPersonBrief(clsPerson Person)
        {
            lblSelectedPersonID.Text = Person.PersonID.ToString();
            lblSelectedPersonFullName.Text = Person.FullName;
        }


        void ClearLoginInfoPage()
        {
            lblSelectedPersonID.Text = "???";
            lblSelectedPersonFullName.Text = "???";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {


            if (_Mode == enMode.AddNew)
            {
                if (ValidatePerson())
                {
                    tpLoginInfo.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tpLoginInfo"];                   
                   ShowSelectedPersonBrief(ctrlPersonCardWithFilter1.SelectedPerson);
                }
                else
                {
                    tpLoginInfo.Enabled = false;
                    tabControl1.SelectedTab = tabControl1.TabPages["tpPersonalInfo"];
                    ClearLoginInfoPage();
                }
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tpLoginInfo"];
            }

        }

        

        void LoadUserData()
        {
            _User = clsUser.FindUser(_UserID);
            if (_User != null)
            {
                lblUserID.Text = _User.UserID.ToString();
                ShowSelectedPersonBrief(_User.PersonInfo);
                txtUserName.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                cbIsActive.Checked = _User.IsActive;
                ctrlPersonCardWithFilter1.LoadPersonInfoInCard(_User.PersonID);
            }
            else
            {
                MessageBox.Show($"User with ID {_UserID} was not found", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }


        void ResetDefaultValues()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    lblHeader.Text = "Add New User";
                    this.Text = "New User";
                    tpLoginInfo.Enabled = false;
                    ctrlPersonCardWithFilter1.FilterEnabled = true;
                    ctrlPersonCardWithFilter1.FilterFocus();
                    break;

                case enMode.Update:
                    lblHeader.Text = "Update User";
                    this.Text = "Update User";
                    tpLoginInfo.Enabled = true;
                    ctrlPersonCardWithFilter1.FilterEnabled = false;
                    break;
            }
            lblUserID.Text = "???";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;
        }


        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            ResetDefaultValues();

            if (_Mode == enMode.Update)
                LoadUserData();
            
            
        }

        bool ValidatePerson()
        {

            ctrlPersonCardWithFilter1.ClickSearch();


            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Select a Valid Person First", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            if (clsUser.IsUserExist_ByPersonID(ctrlPersonCardWithFilter1.PersonID))
            {

                MessageBox.Show("Selected Person already Has a User, Choose another one", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true ;   
        }

 

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
          

            btnSave.Enabled = (e.TabPage == tabControl1.TabPages["tpLoginInfo"]) && tpLoginInfo.Enabled;

           

        }

        private void lblSelectedPersonInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields in Login Info are not valid!. Hover the mouse over the error icons to see the message.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtUserName.Text == "" || txtPassword.Text == "" 
                || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Some fields in Login Info are Empty!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User = new clsUser();

            if (_Mode == enMode.Update)
            {
                _User = clsUser.FindUser(_UserID);
            }

            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.PersonID = int.Parse(lblSelectedPersonID.Text);
            _User.IsActive = cbIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("User Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = _User.UserID.ToString();

              

                if (_Mode == enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    _UserID = _User.UserID;
                    ctrlPersonCardWithFilter1.FilterEnabled = false;
                    lblHeader.Text = "Update User";
                    this.Text = "Update User";

                    if (lblSelectedPersonID.Text != ctrlPersonCardWithFilter1.PersonID.ToString())
                    {
                        ctrlPersonCardWithFilter1.LoadPersonInfoInCard(int.Parse(lblSelectedPersonID.Text));
                    }
                }
                    
            }
            else
            {
                MessageBox.Show("Save has Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        bool ValidateEmptyTextBox(TextBox textBox, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;        
                errorProvider1.SetError(textBox, "This field can not be blank");
                return false;
            }

            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }
        }

       

       

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmptyTextBox(txtUserName, e)) 
            {
                return;
            }
            
            


            bool IsUserNameExist = clsUser.IsUserExist(txtUserName.Text);

            if (IsUserNameExist && txtUserName.Text != _User.UserName) 
            {
                errorProvider1.SetError(txtUserName, "This UserName Already in Use!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }

        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmptyTextBox(txtPassword,e))
                return;
           
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmptyTextBox(txtConfirmPassword, e))
                return;

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Conformation does not match password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void pbPasswordPeek_MouseDown(object sender, MouseEventArgs e)
        {
            if ((PictureBox)sender == pbPasswordPeek)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = false;   
            }
        }

        private void pbPasswordPeek_MouseUp(object sender, MouseEventArgs e)
        {
            if ((PictureBox)sender == pbPasswordPeek)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblSelectedPersonInfo_Click_1(object sender, EventArgs e)
        {

        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
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
