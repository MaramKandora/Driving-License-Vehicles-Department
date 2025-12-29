using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_PresentationLayer
{
    public partial class frmPeopleManagement : Form
    {
        DataTable _dtAllPeople;

        DataTable _dtPeopleList;
        public frmPeopleManagement()
        {
            InitializeComponent();

            LoadPeopleList();
           
        }

        void LoadPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();

            _dtPeopleList = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GenderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        }

        void RefreshPeopleList()
        {
            LoadPeopleList();
            dgvPeople.DataSource = _dtPeopleList;

            lblRecordsNum.Text = dgvPeople.RowCount.ToString();
        }

        void FilterPeopleUsingString(string FilterByColumn, string Value)
        {

            if (!string.IsNullOrWhiteSpace(Value))
                _dtPeopleList.DefaultView.RowFilter = $"{FilterByColumn} Like '{Value}%'";
        

        }

        void FilterPeopleByID(string PersonID)
        {
            _dtPeopleList.DefaultView.RowFilter = $"PersonID = {PersonID}";
          
        }

        
        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            cbPeopleFilter.SelectedIndex = 0;

            RefreshPeopleList();

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 120;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;

            }

        }

        private void txtPeopleFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPeopleFilter.Text) ) 
            {
                _dtPeopleList.DefaultView.RowFilter = "";
                lblRecordsNum.Text = dgvPeople.RowCount.ToString();
                return;
            }

            if (cbPeopleFilter.SelectedItem.ToString() == "Person ID" )
            {

                FilterPeopleByID(txtPeopleFilter.Text);
                
            }
          
            else
            {
                FilterPeopleUsingString(cbPeopleFilter.SelectedItem.ToString().Replace(" ", ""), txtPeopleFilter.Text);
            }

            lblRecordsNum.Text = dgvPeople.RowCount.ToString();

        }

        private void cbPeopleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPeopleFilter.SelectedItem.ToString() == "None")
            {
                txtPeopleFilter.Visible = false;
            }
            else
            {
                txtPeopleFilter.Visible = true;
                txtPeopleFilter.Focus();
                txtPeopleFilter.Text = "";
            }

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNew_UpdatePerson AddNew_UpdatePerson = new frmAddNew_UpdatePerson();
            AddNew_UpdatePerson.ShowDialog();
            RefreshPeopleList();
        }

       
        private void toolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                return;
            frmAddNew_UpdatePerson AddNew_UpdatePerson = new frmAddNew_UpdatePerson((int)dgvPeople.SelectedRows[0].Cells["PersonID"].Value);
            AddNew_UpdatePerson.ShowDialog();
            RefreshPeopleList();
        }

        void DeletePersonImageFromFile(int PersonID)
        {
            clsPerson Person = clsPerson.FindPerson(PersonID);

            if(!string.IsNullOrWhiteSpace(Person.ImagePath))
            {
                File.Delete(Person.ImagePath);
            }

        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                return;

            if(MessageBox.Show("Are You Sure do you Want to Delete Selected Person? ","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                int PersonID = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;

                DeletePersonImageFromFile(PersonID);    
                if (clsPerson.DeletePerson(PersonID)) 
                {
                    MessageBox.Show("Deletion Completed Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Deletion Failed because this Person has Records Linked to it", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }

           
        }

        private void toolStripMenuItem_ShowDetails_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
                return;

            Form PersonInfo = new frmPersonInformation((int)dgvPeople.CurrentRow.Cells["PersonID"].Value);
            PersonInfo.ShowDialog();
        }

        private void toolStripMenuItem_NewPerson_Click(object sender, EventArgs e)
        {
            Form AddNew_UpdatePerson = new frmAddNew_UpdatePerson();
            AddNew_UpdatePerson.ShowDialog();
            RefreshPeopleList();
        }

        private void btnClosePeopleManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPeopleFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbPeopleFilter.SelectedItem.ToString() == "Person ID") 
            {
                e.Handled = !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar);
            }
            
        }

     
    }
}
