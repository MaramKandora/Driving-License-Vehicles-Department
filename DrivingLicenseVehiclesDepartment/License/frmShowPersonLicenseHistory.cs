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

namespace DVLD_PresentationLayer.License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID;
        bool WithFilterEnabled;
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
            WithFilterEnabled = true;
            
        }
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

            WithFilterEnabled = false;
        }

       
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if (WithFilterEnabled)
            {
                ctrlPersonCardWithFilter1.OnPersonSelection += OnPersonSelectionHandler;
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }

           
            ctrlPersonCardWithFilter1.LoadPersonInfoInCard(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            ctrlDriverLicenses1.LoadInfoUsingPersonID(_PersonID);

        }

        void OnPersonSelectionHandler(int SelectedPersonID)
        {

            if (ctrlPersonCardWithFilter1.SelectedPerson != null)
                ctrlDriverLicenses1.LoadInfoUsingPersonID(SelectedPersonID);
            else
                ctrlDriverLicenses1.Clear();
        }
    }
}
