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
using DVLD_PresentationLayer.Properties;
using System.IO;
using DVLD_PresentationLayer.Global_Classes;

namespace DVLD_PresentationLayer
{
    public partial class frmAddNew_UpdatePerson : Form
    {

        bool _IsPersonImageInDefaultMode;

        int _PersonId { get; set; }

        public event Action<int> OnSaveNewPerson;


        public frmAddNew_UpdatePerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

            this._PersonId = -1;

        }
        public frmAddNew_UpdatePerson(int ID)
        {

            InitializeComponent();

            _Mode = enMode.Update;
            lblPersonID.Text = ID.ToString();
                
            this._PersonId = ID;

           
        }

        enum enMode { AddNew, Update};
        enMode _Mode;




        void LoadCountriesList()
        {
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";

        }



        void LoadPersonInfo()
        {
            clsPerson Person = clsPerson.FindPerson(_PersonId);
            if(Person==null)
            {
                MessageBox.Show($"Person with ID {_PersonId} Not Found!", "Person Is Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNationalNo.Text = Person.NationalNo;
            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;
            txtEmail.Text = Person.Email;
            txtPhone.Text = Person.Phone;
            txtAddress.Text = Person.Address;
            cbCountry.SelectedValue = Person.NationalityCountryID;
            dtpDateOfBirth.Value = Person.DateOfBirth;

            if (Person.Gender == clsPerson.enGender.Male)
            {
                rbMale.Checked = true;

            }
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrWhiteSpace(Person.ImagePath))
            {
                pbPersonImage.ImageLocation = Person.ImagePath;
                LinklblRemove.Visible = true;
                _IsPersonImageInDefaultMode = false;
            }
            else
            {
                ShowDefaultPersonImage();
                LinklblRemove.Visible = false;
                _IsPersonImageInDefaultMode = true;
            }



        }


        void ResetDefaultValues()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    lblHeaderAddNew_UpdatePerson.Text = "Add New Person";
                    _IsPersonImageInDefaultMode = true;
                    rbMale.Checked = true;
                    break;

                case enMode.Update:
                    lblHeaderAddNew_UpdatePerson.Text = "Update Person";
                    break;
            }

            LoadCountriesList();

            ShowDefaultPersonImage();
            
            // MinAge = 18
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            // Max Age = 100
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Sudan");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";

        }


        private void frmAddNew_UpdatePerson_Load(object sender, EventArgs e)
        {

            ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                LoadPersonInfo();
            }


        }

       

        void AfterSaveNewPersonEventInvoke()
        {
            Action<int> Handler = OnSaveNewPerson;

            Handler?.Invoke(_PersonId);


        }

     

      

        void CheckNationalNoValidity(string NationalNo)
        {
            if(_Mode==enMode.Update)
            {
                clsPerson CurrentLoadedPerson = clsPerson.FindPerson(_PersonId);

                if (CurrentLoadedPerson != null && NationalNo.Trim() == CurrentLoadedPerson.NationalNo) 
                {
                    return;
                }

            }
           

            if (clsPerson.IsPersonExist(NationalNo.Trim()))
            {
                errorProvider1.SetError(txtNationalNo, "National Number is Used for another Person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, "");

            }
        }



        private void txtRequiredField_Validating(object sender, CancelEventArgs e)
        {
            TextBox textbox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
               
                errorProvider1.SetError(textbox, "This Field Is Required");


            }
            else if (textbox == txtNationalNo)
            {
                CheckNationalNoValidity(txtNationalNo.Text);
            }
            else
            {
                errorProvider1.SetError(textbox, "");


            }

        }

        bool IsThereEmptyRequiredField()
        {
            return (string.IsNullOrWhiteSpace(txtNationalNo.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                 string.IsNullOrWhiteSpace(txtSecondName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                 string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtAddress.Text)) ? true : false;
        }

     

        void SetPersonImage(clsPerson Person)
        {

            if (Person.ImagePath == pbPersonImage.ImageLocation)
            {
                return;
            }


            // Delete Old Image Path From Persons Image Folder if exists
            if (!string.IsNullOrWhiteSpace(Person.ImagePath))
                File.Delete(Person.ImagePath);


            if (_IsPersonImageInDefaultMode) 
            {
                Person.ImagePath = "";
                return;
            }

            //create a new path for the new selected image inside
            //the persons images folder and save it

            string SourceImageFile = pbPersonImage.ImageLocation; 

            if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile)) 
            {
                Person.ImagePath = SourceImageFile;
                pbPersonImage.ImageLocation= SourceImageFile;
               
            }
            else
            {
                MessageBox.Show("Error in Copying Image File","Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
          


        }

  


        void ShowDefaultPersonImage()
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Resources.Female_512;

            }
            else
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (_IsPersonImageInDefaultMode)
            {
                ShowDefaultPersonImage();
            }

        }



        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.Image = null;
                pbPersonImage.Load(openFileDialog1.FileName);

                LinklblRemove.Visible = true;

                _IsPersonImageInDefaultMode = false;


            }


        }

        private void LinklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _IsPersonImageInDefaultMode = true;
            LinklblRemove.Visible = false;

            ShowDefaultPersonImage();


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "");
                return;
            }

            if (!clsValidation.EmailValidation(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");

            }
            else
            {
                errorProvider1.SetError(txtEmail, "");

            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren()||IsThereEmptyRequiredField() || errorProvider1.GetError(txtNationalNo) != string.Empty || errorProvider1.GetError(txtEmail) != string.Empty)
            {
                MessageBox.Show("Some fields are not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               

           


            clsPerson Person1 = new clsPerson();
            if (_Mode == enMode.Update)
            {
                Person1 = clsPerson.FindPerson(_PersonId);
            }
            Person1.NationalNo = txtNationalNo.Text.Trim();
            Person1.FirstName = txtFirstName.Text.Trim();
            Person1.SecondName = txtSecondName.Text.Trim();
            Person1.ThirdName = txtThirdName.Text.Trim();
            Person1.LastName = txtLastName.Text.Trim();
            Person1.DateOfBirth = dtpDateOfBirth.Value;
            Person1.Email = txtEmail.Text.Trim();
            Person1.Phone = txtPhone.Text.Trim();
            Person1.NationalityCountryID = (int)cbCountry.SelectedValue;
            Person1.Address = txtAddress.Text.Trim();

            if (rbFemale.Checked)
            {
                Person1.Gender = clsPerson.enGender.Female;

            }
            else
            {
                Person1.Gender = clsPerson.enGender.Male;
            }


            SetPersonImage(Person1);


            if (Person1.Save())
            {
                MessageBox.Show("Person Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _PersonId = Person1.PersonID;

                if (_Mode == enMode.AddNew)
                {
                    AfterSaveNewPersonEventInvoke();

                    _Mode = enMode.Update;
                    lblPersonID.Text = Person1.PersonID.ToString();
                    lblHeaderAddNew_UpdatePerson.Text = "Update Person";
                    
                }


            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
