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

namespace DVLD_PresentationLayer
{
    public partial class frmScheduleTest : Form
    {
        int _LDLAppID;
        int _AppointmentID;
        clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public frmScheduleTest(int LDLAppID,clsTestType.enTestType TestType,  int AppointmentID =-1)
        {
            InitializeComponent();
            this._LDLAppID = LDLAppID;  
            this._AppointmentID = AppointmentID;
            this._TestType = TestType;  
        }



        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID= _TestType;    
            ctrlScheduleTest1.LoadInfo(_LDLAppID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
