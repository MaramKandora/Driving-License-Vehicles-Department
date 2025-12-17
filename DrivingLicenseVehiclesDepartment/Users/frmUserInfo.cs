using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_PresentationLayer.Users
{
    public partial class frmUserInfo : Form
    {
        int _UserID;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;   
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserInformationCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
