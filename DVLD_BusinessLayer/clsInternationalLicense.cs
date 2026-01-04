using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        int _InternationalInternationalLicenseID;
        public int InternationalLicenseID { get { return _InternationalInternationalLicenseID; } }
        int _ApplicationID;
        public int ApplicationID
        {
            get { return _ApplicationID; }
            set
            {
                _ApplicationID = value;
                if (value == -1)
                {
                    _ApplicationInfo = null;
                    return;
                }


                _ApplicationInfo = clsApplication.FindBaseApplicationByID(value);
                if (ApplicationInfo == null)
                    _ApplicationID = -1;
            }
        }

        clsApplication _ApplicationInfo;
        public clsApplication ApplicationInfo { get { return _ApplicationInfo; } }

        int _LocalLicenseID;
        public int LocalLicenseID
        {
            get { return _LocalLicenseID; }
            set
            {
                _LocalLicenseID = value;
                if (value == -1)
                {
                    _LocalLicenseInfo = null;
                    return;
                }


                _LocalLicenseInfo = clsLicense.FindLicenseByLicenseID(_LocalLicenseID);
                if (LocalLicenseInfo == null)
                    _ApplicationID = -1;
            }
        }

        clsLicense _LocalLicenseInfo;
        public clsLicense LocalLicenseInfo { get { return _LocalLicenseInfo; } }


        int _DriverID;
        public int DriverID
        {
            get { return _DriverID; }
            set
            {
                _DriverID = value;
                if (value == -1)
                {
                    _DriverInfo = null;
                    return;
                }


                _DriverInfo = clsDriver.FindDriverUsingDriverID(_DriverID);
                if (_DriverInfo == null)
                    _DriverID = -1;
            }
        }

        clsDriver _DriverInfo;
        public clsDriver DriverInfo { get { return _DriverInfo; } }

       

        DateTime _IssueDate;
        public DateTime IssueDate { get { return _IssueDate; } }

        DateTime _ExpirationDate;
        public DateTime ExpirationDate { get { return _ExpirationDate; } }

       
        public bool IsActive { get; set; }



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

        public clsInternationalLicense()
        {
            _InternationalInternationalLicenseID = -1;
            DriverID = -1;
            ApplicationID = -1;
            LocalLicenseID = -1;
            _IssueDate = DateTime.Now;
            _ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;

        }

        clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate
          , DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this._InternationalInternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LocalLicenseID = IssuedUsingLocalLicenseID;
            this._IssueDate = IssueDate;
            this._ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }


        static public clsInternationalLicense FindLicenseByInternationalLicenseID(int InternationalLicenseID)
        {

            int ApplicationID = -1, DriverID = -1, CreatedByUserID = -1, IssuedUsingLocalLicenseIDID = -1;

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;


            if (clsInternationalLicenseData.FindInternationalLicenseByInternationalLicenseID(InternationalLicenseID,
                ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseIDID, ref IssueDate,
                ref ExpirationDate, ref IsActive,  ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, (int)IssuedUsingLocalLicenseIDID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            }
            else
            {
                return null;
            }

        }

        static public clsInternationalLicense FindLicenseByLocalApplicationID(int LocalApplicationID)
        {

            int InternationalLicenseID = -1, DriverID = -1, CreatedByUserID = -1, ApplicationID = -1;

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;


            if (clsInternationalLicenseData.FindInternationalLicenseByLDLAppID(LocalApplicationID, ref ApplicationID,
                ref InternationalLicenseID, ref DriverID, ref IssueDate,
                ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, LocalApplicationID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            }
            else
            {
                return null;
            }

        }

        bool AddNewInternationalLicense()
        {
            this._IssueDate = DateTime.Now;

            this._ExpirationDate = this.IssueDate.AddYears(1);

            this._InternationalInternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID,
                this.LocalLicenseID, this.IssueDate, this.ExpirationDate,
                this.IsActive, this.CreatedByUserID);

            return this._InternationalInternationalLicenseID != -1;
        }

        bool UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID,
                this.LocalLicenseID, this.IssueDate, this.ExpirationDate,
                this.IsActive,this.CreatedByUserID);
        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.DeleteInternationalLicense(InternationalLicenseID);
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewInternationalLicense())
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
                        return UpdateInternationalLicense();
                    }

                default:
                    return false;
            }

        }
        public static bool IsLicenseExistByInternationalLicenseID(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.IsLicenseExistByInternationalLicenseID(InternationalLicenseID);
            
        }

        public static int GetActiveInternationalLicenseForDriver(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseID(DriverID);
        }
        public static bool DoesDriverHaveActiveInternationalLicense(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseID(DriverID) != -1;
        }
        public static DataTable GetAllInternationalLicensesForDriver(int DriverID)
        {
            return clsInternationalLicenseData.GetAllInternationalLicensesForDriver(DriverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

    }
}
