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
using DVLD_PresentationLayer.Global_Classes;

namespace DVLD_PresentationLayer.Applications
{
    public partial class frmAddNew_UpdateLDLApplication : Form
    {
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        enum enMode { AddNew ,Update}
        enMode _Mode;
        public frmAddNew_UpdateLDLApplication()
        {
            InitializeComponent();
            _LDLApplication = null;
            _LDLApplicationID = -1;
            _Mode = enMode.AddNew;  
        }

        public frmAddNew_UpdateLDLApplication(int LDLAppID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLAppID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(LDLAppID);
            _Mode = enMode.Update;
        }

        void ResetDefaultValues()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    lblHeader.Text = "Add New Local Driving License Application";
                    this.Text = "New Local Driving License Application";
                    tpApplicationInfo.Enabled = false;
                    ctrlPersonCardWithFilter1.FilterEnabled = true;
                    ctrlPersonCardWithFilter1.FilterFocus();
                    break;

                case enMode.Update:
                    lblHeader.Text = "Update Local Driving License Application";
                    this.Text = "Update Local Driving License Application";
                    tpApplicationInfo.Enabled = true;
                    ctrlPersonCardWithFilter1.FilterEnabled = false;
                    break;
            }
            lblApplicationID.Text = "???";
            lblCreatedByUserName.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.NewLocalLicense).ApplicationFees.ToString();
            cbLicenseClasses.SelectedValue = 3;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        void ShowApplicantPersonBrief(clsPerson Person)
        {
            lblSelectedPersonID.Text = Person.PersonID.ToString();
            lblSelectedPersonFullName.Text = Person.FullName;
        }

        void LoadApplicationData()
        {
            if (_LDLApplication == null)
            {
                MessageBox.Show($"Loading Application Has Failed. No Application with Id \'{_LDLApplicationID}\'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlPersonCardWithFilter1.LoadPersonInfoInCard(_LDLApplication.ApplicantPersonID);
            lblApplicationID.Text = _LDLApplication.ApplicationID.ToString();
            lblCreatedByUserName.Text= _LDLApplication.CreatedByUserInfo.UserName;
            lblDate.Text = _LDLApplication.ApplicationDate.ToString("dd/MM/yyyy");
            lblFees.Text = _LDLApplication.Fees.ToString();
            cbLicenseClasses.SelectedValue = _LDLApplication.LicenseClassID;
            ShowApplicantPersonBrief(_LDLApplication.ApplicantPersonInfo);

        }
        void LoadLicenseClassesData()
        {
            cbLicenseClasses.DataSource = clsLicenseClass.GetAllLicenseClasses().DefaultView.ToTable(false, "LicenseClassID","ClassName");
            cbLicenseClasses.DisplayMember = "ClassName";
            cbLicenseClasses.ValueMember = "LicenseClassID";
            cbLicenseClasses.SelectedValue = 3;


        }
        private void frmAddNew_UpdateLDLApplication_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            LoadLicenseClassesData();
            ResetDefaultValues();

            if (_Mode == enMode.Update)
                LoadApplicationData();
        }

        bool ValidatePerson()
        {

            ctrlPersonCardWithFilter1.ClickSearch();


            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Select a Valid Person First", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            return true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (ValidatePerson())
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
                }
                else
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tpPersonalInfo"];
                  
                }
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            if (e.TabPage == tabControl1.TabPages["tpApplicationInfo"] ) 
            {
                if (ctrlPersonCardWithFilter1.PersonID != -1)
                {
                    tpApplicationInfo.Enabled = true;
                    ShowApplicantPersonBrief(ctrlPersonCardWithFilter1.SelectedPerson);
                }
                else
                {
                    tpApplicationInfo.Enabled = false;
                    lblSelectedPersonID.Text = "???";
                    lblSelectedPersonFullName.Text = "???";
                }
                  
            }

            btnSave.Enabled = (e.TabPage == tabControl1.TabPages["tpApplicationInfo"] && tpApplicationInfo.Enabled);


        }


        private void btnSave_Click(object sender, EventArgs e)
        {


            if (clsLicenseClass.DoesPersonAlreadyHaveApplicationForLicenseClass(ctrlPersonCardWithFilter1.PersonID, (int)cbLicenseClasses.SelectedValue)) 
            {
                MessageBox.Show($"Selected Person Already has Local Driving License Application of \'{cbLicenseClasses.Text}\'", "Didn`t Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }


            if (!clsLicenseClass.CheckAgeValidityForLicenseClass(ctrlPersonCardWithFilter1.SelectedPerson.DateOfBirth,
                (clsLicenseClass.enLicenseClasses)cbLicenseClasses.SelectedValue))

            {
                MessageBox.Show($"Selected Person`s Age is Under the minimum allowed age for the selected license class", "Didn`t Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }
           

            _LDLApplication = new clsLocalDrivingLicenseApplication();

            if (_Mode == enMode.Update)
            {
                _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(_LDLApplicationID);  
            }

            _LDLApplication.LicenseClassID = (clsLicenseClass.enLicenseClasses)cbLicenseClasses.SelectedValue;
            _LDLApplication.ApplicantPersonID = int.Parse(lblSelectedPersonID.Text);
            _LDLApplication.enApplicationTypeID = clsApplicationType.enApplicationTypes.NewLocalLicense;
            _LDLApplication.Fees = Convert.ToSingle(lblFees.Text);
            _LDLApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_LDLApplication.Save())
            {
                MessageBox.Show("Application Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                if (_Mode == enMode.AddNew)
                {
                    lblApplicationID.Text = _LDLApplication.LDLApplicationID.ToString();
                    _Mode = enMode.Update;
                    _LDLApplicationID = _LDLApplication.LDLApplicationID;
                    ctrlPersonCardWithFilter1.FilterEnabled = false;
                    lblHeader.Text = "Update Local Driving License Application";
                    this.Text = "Update Local Driving License Application";

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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
