using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        int _TestAppointmentID;
        public int TestAppointmentID { get { return _TestAppointmentID; } }

        int _LocalDrivingLicenseLocalDrivingLicenseApplicationID;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseLocalDrivingLicenseApplicationID; }
            set
            {
                _LocalDrivingLicenseLocalDrivingLicenseApplicationID = value;
                if (value == -1)
                {
                    _LDLApplicationInfo = null;
                    return;
                }


                _LDLApplicationInfo = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(value);
                if (LDLApplicationInfo == null)
                    _LocalDrivingLicenseLocalDrivingLicenseApplicationID = -1;
            }
        }

        clsLocalDrivingLicenseApplication _LDLApplicationInfo;
        public clsLocalDrivingLicenseApplication LDLApplicationInfo { get { return _LDLApplicationInfo; } }

       

       clsTestType.enTestType _TestTypeID;
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;
                _TestTypeInfo = clsTestType.FindTestType(_TestTypeID);
            }
        }

        clsTestType _TestTypeInfo;
        public clsTestType TestTypeInfo { get { return _TestTypeInfo; } }



        public DateTime AppointmentDate { get; set; }


        public float PaidFees { get; set; }
        public bool IsLocked { get; set; }


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


        int _RetakeTestApplicationID;
        public int RetakeTestApplicationID
        {
            get { return _RetakeTestApplicationID; }
            set
            {
                _RetakeTestApplicationID = value;
                if (value == -1)
                {
                    _RetakeTestApplicationInfo = null;
                    return;
                }


                _RetakeTestApplicationInfo = clsApplication.FindBaseApplicationByID(_RetakeTestApplicationID);
                if (_RetakeTestApplicationInfo == null)
                    _RetakeTestApplicationID = -1;
            }
        }

        clsApplication _RetakeTestApplicationInfo;
        public clsApplication RetakeTestApplicationInfo { get { return _RetakeTestApplicationInfo; } }


        enum enMode { AddNew, Update }
        enMode _Mode;

        clsTestAppointment()
        {
            _TestAppointmentID = -1;
            RetakeTestApplicationID = -1;
            LocalDrivingLicenseApplicationID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            IsLocked = false;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;

        }

        clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
        float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this._TestAppointmentID = TestAppointmentID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestTypeID = TestTypeID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }


        static public clsTestAppointment FindTestAppointmentByTestAppointmentID(int TestAppointmentID)
        {

            int LocalDrivingLicenseApplicationID = -1, RetakeTestApplicationID = -1, CreatedByUserID = -1, TestTypeID = -1;

            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;


            if (clsTestAppointmentData.FindTestAppointmentByID(TestAppointmentID,ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID)) 
            {
                return new clsTestAppointment(TestAppointmentID,(clsTestType.enTestType) TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            }
            else
            {
                return null;
            }

        }

        static public clsTestAppointment FindTestAppointmentByRetakeTestApplicationID(int RetakeTestApplicationID)
        {

            int LocalDrivingLicenseApplicationID = -1, TestAppointmentID = -1, CreatedByUserID = -1, TestTypeID = -1;

            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;


            if (clsTestAppointmentData.FindTestAppointmentByRetakeTestApplicationID(RetakeTestApplicationID,ref TestAppointmentID,
                ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            }
            else
            {
                return null;
            }

        }
        public static bool IsTestAppointmentExistByTestAppointmentID(int TestAppointmentID)
        {
            return clsTestAppointmentData.IsTestAppointmentExistByTestAppointmentID(TestAppointmentID);
        }

        public static bool IsTestAppointmentExistByRetakeTestApplicationID(int RetakeTestApplicationID)
        {
            return clsTestAppointmentData.IsTestAppointmentExistByRetakeTestID(RetakeTestApplicationID);
        }

        bool AddNewTestAppointment()
        {


            this._TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return this._TestAppointmentID != -1;
        }

        bool UpdateLicense()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointmentID);
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewTestAppointment())
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
                        return UpdateLicense();
                    }

                default:
                    return false;
            }

        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

    }
}
