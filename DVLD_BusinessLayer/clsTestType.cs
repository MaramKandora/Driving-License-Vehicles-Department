using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, PracticalTest = 3 }


        public enTestType enTestType1 { get; set; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription {  get; set; }    
        public float TestFees { get; set; }

        enum enMode { AddNew, Update };
        enMode _Mode;

        public clsTestType()
        {
            this.enTestType1 = 0;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestFees = 0;
            _Mode = enMode.AddNew;
        }
        private clsTestType(enTestType TestType, string TestTypeTitle, string TestTypeDescription, float TestFees)
        {
            this.enTestType1 = TestType;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription= TestTypeDescription;  
            this.TestFees = TestFees;
            _Mode = enMode.Update;
        }
        public static clsTestType FindTestType(enTestType TestType)
        {
            string TestTypeTitle = "", TestTpeDescription = "";
            float Fees = 0;
            if (clsTestTypesDataAccess.FindTestTypeUsingID((int)TestType, ref TestTypeTitle, ref TestTpeDescription, ref Fees))
            {
                return new clsTestType(TestType, TestTypeTitle, TestTpeDescription, Fees);
            }
            else
            {
                return null;
            }
        }

        private bool AddNewTestType()
        {
            if (Enum.TryParse(clsTestTypesDataAccess.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestFees).ToString(), out enTestType TestType))
            {
                this.enTestType1= TestType;
                return true;
            }
            else
            {
                this.enTestType1 = enTestType.VisionTest;
                return false;
            }
               
        }

        private bool UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType((int)this.enTestType1, this.TestTypeTitle, this.TestTypeDescription, this.TestFees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (AddNewTestType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return UpdateTestType();

                default:
                    return false;
            }
        }




        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }

    }
}

