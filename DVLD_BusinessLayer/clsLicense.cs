using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
        int _LicenseID;
        public int LicenseID {  get { return _LicenseID; } }
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


                _DriverInfo = clsDriver.FindDriver(_DriverID);
                if (_DriverInfo == null)
                    _DriverID = -1;
            }
        }

        clsDriver _DriverInfo;
        public clsDriver DriverInfo { get { return _DriverInfo; } }

        clsLicenseClass.enLicenseClasses _LicenseClassID;
        public clsLicenseClass.enLicenseClasses LicenseClassID
        {
            get { return _LicenseClassID; } 

            set
            {
                _LicenseClassID = value;
                _LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(_LicenseClassID);
            }
        }

        clsLicenseClass _LicenseClassInfo;
        public clsLicenseClass LicenseClassInfo { get { return _LicenseClassInfo; } }

        DateTime _IssueDate;
        public DateTime IssueDate { get { return _IssueDate; } }

        DateTime _ExpirationDate;
        public DateTime ExpirationDate { get { return _ExpirationDate; } }

        public string Notes { get; set; }

        public float PaidFees { get; set; } 
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

       public enum enIssueReason {FirstTime=1, Renew , ReplacementForDamaged, ReplacementForLost }

        public enIssueReason IssueReason { get; set; }

        enum enMode  {AddNew, Update}
        enMode _Mode;

        clsLicense()
        {
            _LicenseID = -1;
            DriverID = -1;
            ApplicationID = -1;
            LicenseClassID = clsLicenseClass.enLicenseClasses.Ordinary;
            _IssueDate = DateTime.Now;
            _ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;

        }

        clsLicense(int LicenseID, int ApplicationID, int DriverID, clsLicenseClass.enLicenseClasses LicenseClass, DateTime IssueDate
          , DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this._LicenseID = LicenseID;    
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClass;
            this._IssueDate = IssueDate;
            this._ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;   
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }


        static public clsLicense FindLicenseByLicenseID(int LicenseID)
        {

            int ApplicationID = -1, DriverID = -1, CreatedByUserID = -1, LicenseClassID = -1;
            
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0 ;


            if (clsLicenseData.FindLicenseByLicenseID(LicenseID,ref ApplicationID, ref DriverID, ref LicenseClassID,ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID,(clsLicenseClass.enLicenseClasses) LicenseClassID,
                    IssueDate, ExpirationDate, Notes, PaidFees, IsActive,(enIssueReason) IssueReason, CreatedByUserID);

            }
            else
            {
                return null;
            }

        }

        static public clsLicense FindLicenseByApplicationIDID(int ApplicationID)
        {

            int LicenseID = -1, DriverID = -1, CreatedByUserID = -1, LicenseClassID = -1;

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;


            if (clsLicenseData.FindLicenseByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, (clsLicenseClass.enLicenseClasses)LicenseClassID,
                    IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);

            }
            else
            {
                return null;
            }

        }

        public static bool IsLicenseExistByLicenseID(int LicenseID)
        {
            return clsLicenseData.IsLicenseExistByLicenseID(LicenseID);
        }

        public static bool IsLicenseExistByApplicationID(int ApplicationID)
        {
            return clsLicenseData.IsLicenseExistByApplicationID(ApplicationID);
        }

        bool AddNewLicense()
        {


            this._LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, (int)this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return this._LicenseID != -1;
        }

        bool UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, (int)this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicenseData.DeleteLicense(LicenseID);
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewLicense())
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

        //public static DataTable GetAllLicenses()

        //{
            
        //}


    }
}
