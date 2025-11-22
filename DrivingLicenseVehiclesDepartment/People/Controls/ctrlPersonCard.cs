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

namespace DVLD_PresentationLayer
{
    public partial class ctrlPersonCard : UserControl
    {
        int _PersonID;

        clsPerson _Person;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return _PersonID; }

        }

        public clsPerson SelectedPerson
        {
            get { return _Person; }
        }


        void LoadPersonImage()
        {
            if (_Person.ImagePath == "")
            {

                pbPersonImage.Image =
                    (_Person.Gender == clsPerson.enGender.Male) ? Resources.Male_512 :  Resources.Female_512;

            }
            else
            {
                string ImagePath = _Person.ImagePath;
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
        }

        void FillPersonInfo()
        {
            llblEditPersonInfo.Enabled = true;

            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;

            if (!string.IsNullOrWhiteSpace(_Person.ThirdName))
                lblFullName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            else
                lblFullName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.LastName;

            lblGender.Text = _Person.Gender.ToString();
            pbGender.Image =
                (_Person.Gender == clsPerson.enGender.Male) ? Resources.Man_32 : Resources.Woman_32;

            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/mm/yyyy");
            lblEmail.Text = _Person.Email;
            
            lblCountry.Text = _Person.CountryInfo.CountryName;
            LoadPersonImage();

        }


        void ShowDefaultPersonInfo()
        {
            llblEditPersonInfo.Enabled = false;
            _PersonID = -1;
            lblPersonID.Text = "???";
            lblNationalNo.Text = "???";
            lblFullName.Text = "???";
            lblGender.Text = "???";
            lblPhone.Text = "???";
            lblAddress.Text = "???";
            lblDateOfBirth.Text = "???";
            lblEmail.Text = "???";
            pbPersonImage.Image = Resources.Male_512;
            pbGender.Image= Resources.Man_32;
            lblGender.Text = "???";


        }
       

       

       public void LoadPersonInfo(int ID)
        {
            

            _Person = clsPerson.FindPerson(ID);

            if (_Person == null)
            {
                MessageBox.Show("Person`s Info is not found");
                ShowDefaultPersonInfo();
                return ;
            }

            this._PersonID = _Person.PersonID;
            FillPersonInfo();
            
        }


        public void LoadPersonInfo(string NationalNo)
        {
           

            _Person = clsPerson.FindPerson(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show("Person`s Info is not found");
                ShowDefaultPersonInfo();
                return ;
            }

            this._PersonID = _Person.PersonID;
            FillPersonInfo();
           
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddNew_UpdatePerson EditPersonInfo = new frmAddNew_UpdatePerson(this._PersonID);
            EditPersonInfo.ShowDialog();
            LoadPersonInfo(this._PersonID);
        }
    }
}
