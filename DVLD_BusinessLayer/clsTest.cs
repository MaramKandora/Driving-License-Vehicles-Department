using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        int _TestID;
        public int TestID { get { return _TestID; } }
        int _TestAppointmentID;
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
            set
            {
                _TestAppointmentID = value;
                if (value == -1)
                {
                    TestAppointmentInfo = null;
                    return;
                }


                TestAppointmentInfo = clsTestAppointment.FindTestAppointmentByTestAppointmentID(value);
                if (TestAppointmentInfo == null)
                    _TestAppointmentID = -1;
            }
        }

        public clsTestAppointment TestAppointmentInfo { get; set; }


        public string Notes { get; set; }
        public bool TestResult { get; set; }


        int _CreatedByUserID;
        public int CreatedByUserID
        {
            get { return _CreatedByUserID; }
            set
            {
                _CreatedByUserID = value;
                if (value == -1)
                {
                    _CreatedByUserInfo = null;
                    return;
                }

                _CreatedByUserInfo = clsUser.FindUser(_CreatedByUserID);
                if (CreatedByUserInfo == null)
                    _CreatedByUserID = -1;
            }
        }

        clsUser _CreatedByUserInfo;
        public clsUser CreatedByUserInfo { get { return _CreatedByUserInfo; } }


        enum enMode { AddNew, Update }
        enMode _Mode;

        public clsTest()
        {
            _TestID = -1;
            TestAppointmentID = -1;
            Notes = "";
            TestResult = false;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;

        }

        clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this._TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.Notes = Notes;
            this.TestResult = TestResult;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }


        static public clsTest FindTestByTestID(int TestID)
        {

            int TestAppointmentID = -1, CreatedByUserID = -1;
            string Notes = "";
            bool TestResult = false;



            if (clsTestData.FindTestByTestID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID)) 
            {

                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

              

            }
            else
            {
                return null;
            }

        }

      
        static public clsTest FindTestByAppointmentID(int TestAppointmentID)
        {
            int TestID = -1, CreatedByUserID = -1;
            string Notes = "";
            bool TestResult = false;



            if (clsTestData.FindTestByAppointmentID(TestAppointmentID, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
              
                    return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

               
            }
            else
            {
                return null;
            }
        }
        public static bool IsTestExist(int TestID)
        {
            return clsTestData.IsTestExistByTestID(TestID);
        }

 
        bool AddNewTest()
        {
            
            this._TestID = clsTestData.AddNewTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return this._TestID != -1;
        }

        bool UpdateTest()
        {
            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public static bool DeleteTest(int TestID)
        {
            return clsTestData.DeleteTest(TestID);
        }


        public static byte GetNumberOfPassedTests(int LDLAppID)
        {
            return clsTestData.GetPassedTestsCount(LDLAppID);
        }


        public static int GetPassedTestIDForTestType(int LDLAppID,clsTestType.enTestType TestType)
        {
            return clsTestData.GetPassedTestIDForTestType(LDLAppID, (int)TestType);
        }

        public static bool IsTestPassed(int LDLAppID, clsTestType.enTestType TestType)
        {
            return clsTestData.GetPassedTestIDForTestType(LDLAppID, (int)TestType) != -1;
        }

     

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewTest())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                case enMode.Update:
                    {
                        return UpdateTest();
                    }

                default:
                    return false;
            }

        }
    }
}
