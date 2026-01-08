using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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


                _DriverInfo = clsDriver.FindDriverUsingDriverID(_DriverID);
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

        public string GetIssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";

                    case enIssueReason.Renew:
                        return "Renew";

                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement For Damaged";

                    case enIssueReason.ReplacementForLost:
                        return "Replacement For Lost";

                    default:
                        return "Unknown";
                }
            }
        }

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.IsLicenseDetained(this.LicenseID);
            }
        }

        public bool IsExpired
        {
            get
            {
                return this.ExpirationDate < DateTime.Now;
            }
        }
        enum enMode  {AddNew, Update}
        enMode _Mode;

        public clsLicense()
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

        static public clsLicense FindLicenseByApplicationID(int ApplicationID)
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
            return clsLicenseData.GetLicenseIDUsingApplicationID(ApplicationID) != -1 ;
        }

        public static int GetLicenseIDUsingApplicationID(int ApplicationID)
        {
            return clsLicenseData.GetLicenseIDUsingApplicationID(ApplicationID);
        }

        bool AddNewLicense()
        {
            this._IssueDate = DateTime.Now;

            
                this._ExpirationDate = this.IssueDate.AddYears(clsLicenseClass.FindLicenseClassByID(this.LicenseClassID).DefaultValidityLength);

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

        public static DataTable GetAllLocalLicensesForDriver(int DriverID)

        {
            return clsLicenseData.GetAllLocalLicensesForDriver(DriverID);
        }

        public bool Deactivate()
        {
            this.IsActive = false;
           return clsLicenseData.DeactivateLicense(this.LicenseID);
        }


        public int IssueInternationalLicense(int CreatedByUserID)
        {
            if (this.LicenseID == -1 || !this.IsActive || this.IsDetained)
                return -1;

            clsApplication Application = new clsApplication();
            Application.enApplicationStatusID = clsApplication.enApplicationStatus.Completed;
            Application.enApplicationTypeID = clsApplicationType.enApplicationTypes.NewInternationalL;
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.CreatedByUserID = CreatedByUserID;
            Application.Fees = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.NewInternationalL).ApplicationFees;
            if (!Application.Save())
            {
                return -1;
            }

            clsInternationalLicense InternationalLicense= new clsInternationalLicense();
            InternationalLicense.ApplicationID = Application.ApplicationID;
            InternationalLicense.DriverID = this.DriverID;
            InternationalLicense.LocalLicenseID = this.LicenseID;
            InternationalLicense.IsActive = true;
            InternationalLicense.CreatedByUserID= CreatedByUserID;

            if (InternationalLicense.Save())
            {
                return InternationalLicense.InternationalLicenseID;
            }
            else
            {
                return -1;
            }

        }

        public clsLicense RenewLicense(int CreatedByUserID, string Notes)
        {
            if (this.LicenseID == -1|| !this.IsExpired || !this.IsActive)
                return null;

            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID= this.DriverInfo.PersonID;
            Application.CreatedByUserID = CreatedByUserID;
            Application.enApplicationStatusID = clsApplication.enApplicationStatus.Completed;
            Application.enApplicationTypeID = clsApplicationType.enApplicationTypes.RenewLicense;
            Application.Fees = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.RenewLicense).ApplicationFees;
            if (!Application.Save())
                return null;

            if (!this.Deactivate())
                return null;  
           

            clsLicense NewLicense = new clsLicense();
            NewLicense.Notes = Notes;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.IsActive = true;
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.PaidFees = clsLicenseClass.FindLicenseClassByID(this.LicenseClassID).Fees;
            NewLicense.LicenseClassID = this.LicenseClassID;  
            if (NewLicense.Save())
            {
                return NewLicense;
            }
            else
            {
                return null;  
            }
            

        }

        public enum enReplacementMode { ForLost, ForDamaged }
        public clsLicense Replace(enReplacementMode ReplacementMode,int CreatedByUserID)
        {
            if (this.LicenseID == -1  || !this.IsActive || this.IsDetained)
                return null;

            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.CreatedByUserID = CreatedByUserID;
            Application.enApplicationStatusID = clsApplication.enApplicationStatus.Completed;
            Application.enApplicationTypeID = (ReplacementMode == enReplacementMode.ForDamaged) ? clsApplicationType.enApplicationTypes.Replacement_Damaged
                : clsApplicationType.enApplicationTypes.Replacement_Lost;

            Application.Fees = (ReplacementMode == enReplacementMode.ForDamaged) ? clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.Replacement_Damaged).ApplicationFees
                : clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.Replacement_Lost).ApplicationFees;
            if (!Application.Save())
                return null;

            if (!this.Deactivate())
                return null;


            enIssueReason IssueReason = (ReplacementMode == enReplacementMode.ForDamaged)? enIssueReason.ReplacementForDamaged : enIssueReason.ReplacementForLost;

            int NewLicenseID = clsLicenseData.AddNewLicense(Application.ApplicationID, this.DriverID, (int)this.LicenseClassID, DateTime.Now,
                this.ExpirationDate, this.Notes, 0, true, (byte)IssueReason, CreatedByUserID);
            if (NewLicenseID !=-1)
            {
                return clsLicense.FindLicenseByLicenseID(NewLicenseID);
            }
            else
            {
                return null;
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            // it returns Detain ID, or -1 if detention failed
            if (this.LicenseID == -1 )
                return -1;


            clsDetainedLicense DetainedLicense = new clsDetainedLicense();

            DetainedLicense.LicenseID = this.LicenseID; 
            DetainedLicense.FineFees = FineFees;
            DetainedLicense.CreatedByUserID = CreatedByUserID;


            if (DetainedLicense.Save())
                return DetainedLicense.DetainID;
            else
                return -1;
            
            

        }

       

        //Reminder: there are more functions in instructor`s code, Check them out
    }
}
