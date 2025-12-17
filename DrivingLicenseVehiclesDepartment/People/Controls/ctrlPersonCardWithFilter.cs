using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_PresentationLayer.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelection;

       
        void OnPersonSelectionInvoke(int PersonID)
        { 
            Action<int> handler= OnPersonSelection; 
            if (handler != null)
            {
                handler.Invoke(PersonID);
            }
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPerson
        {
            get { return ctrlPersonCard1.SelectedPerson; }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; } 

            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        private bool _ShowAddPersonButton = true;

        public bool ShowAddPersonButton
        {
            get { return _ShowAddPersonButton; }

            set
            {
                _ShowAddPersonButton= value;
                btnAddNewPerson.Enabled = _ShowAddPersonButton; 
            }
        }


        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFindPersonBy.SelectedIndex = 0;
            txtFindBy.Focus();
        }

        public void LoadPersonInfoInCard(int PersonID)
        {
            cbFindPersonBy.SelectedIndex = 1;
            txtFindBy.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);

        }

        private void SearchForPerson()
        {
            if (string.IsNullOrWhiteSpace(txtFindBy.Text))
            {
                ctrlPersonCard1.ClearPersonCard();
                return;
            }

            int PersonID = -1;

            switch (cbFindPersonBy.Text)
            {
                case "Person ID":

                    if (int.TryParse(txtFindBy.Text, out PersonID))
                    {
                        LoadPersonInfoInCard(PersonID);

                    }
                    else
                    {
                        MessageBox.Show("Person ID Should be Numbers only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    break;

                case "National No":
                   ctrlPersonCard1.LoadPersonInfo(txtFindBy.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelection != null && FilterEnabled) 
            {
                OnPersonSelectionInvoke(PersonID);
            }

        }

        public void ClickSearch()
        {
            btnFindPerson.PerformClick();
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {

            SearchForPerson();

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNew_UpdatePerson AddNewPerson = new frmAddNew_UpdatePerson();
            AddNewPerson.OnSaveNewPerson += AfterAddingNewPerson_Handler;
            AddNewPerson.ShowDialog();  
        }

        void AfterAddingNewPerson_Handler(int PersonID)
        {
            LoadPersonInfoInCard(PersonID);
            cbFindPersonBy.SelectedIndex = 1;
            txtFindBy.Text = PersonID.ToString();
            

        }

        

        private void txtFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFindPersonBy.Text == "Person ID")
            {
                e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

            if (e.KeyChar == (char)Keys.Enter) 
            {
                btnFindPerson.PerformClick();
            }

        }

        private void cbFindPersonBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindBy.Text = "";
            txtFindBy.Focus();
        }

        private void txtFindBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFindBy.Text.Trim()))
            {
              
                errorProvider1.SetError(txtFindBy, "This field is required!");
            }
            else
            {
               
                errorProvider1.SetError(txtFindBy, null);
            }
        }

        public void FilterFocus()
        {
            txtFindBy.Select();   
        }

        
    }
}
