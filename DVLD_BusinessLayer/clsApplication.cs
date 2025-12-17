using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        private int _ApplicationID;
        public int ApplicationID { get { return _ApplicationID; }  }

        int _ApplicantPersonID;
        public int ApplicantPersonID
        {
            get { return _ApplicantPersonID; }  

            set
            {
                _ApplicantPersonID = value;

                if (value == -1)
                {
                    _ApplicationTypeInfo = null;
                    return;
                }
                
                _ApplicantPersonInfo = clsPerson.FindPerson(_ApplicantPersonID);
                if (_ApplicantPersonInfo == null)
                    _ApplicantPersonID = -1;

            }
        }

        clsPerson _ApplicantPersonInfo;
        public clsPerson ApplicantPersonInfo { get { return _ApplicantPersonInfo; } }

        protected DateTime _ApplicationDate;
        public DateTime ApplicationDate { get { return _ApplicationDate; } }

        clsApplicationType.enApplicationTypes _enApplicationTypeID;
        public clsApplicationType.enApplicationTypes enApplicationTypeID
        {
            get { return _enApplicationTypeID; }
            set
            {
                _enApplicationTypeID = value;
                _ApplicationTypeInfo = clsApplicationType.FindApplicationType(_enApplicationTypeID);
                

            }
        }
        clsApplicationType _ApplicationTypeInfo;
        public clsApplicationType ApplicationTypeInfo { get { return _ApplicationTypeInfo; } }


        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 }

        private enApplicationStatus _enApplicationStatus;
        public enApplicationStatus enApplicationStatus1 { get {return _enApplicationStatus; } }

        private DateTime _LastStatusDate;
        public DateTime LastStatusDate { get { return _LastStatusDate; } }

        public float Fees { get; set; }

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


        enum enMode { AddNew, Update};
        enMode _Mode;
        public clsApplication()
        {
            _ApplicationID = -1;
            _ApplicantPersonID = -1;
            _ApplicantPersonInfo = null;
            _ApplicationDate = DateTime.Now;
            enApplicationTypeID = clsApplicationType.enApplicationTypes.NewLocalLicense;
            _enApplicationStatus = enApplicationStatus.New;

            Fees = 0;
            _LastStatusDate = DateTime.Now; 
            _CreatedByUserID = -1;
            _CreatedByUserInfo = null;

            _Mode = enMode.AddNew;

        }

        protected clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, clsApplicationType.enApplicationTypes ApplicationType,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this._ApplicationID = ApplicationID;    
            this.ApplicantPersonID = ApplicantPersonID; 
            this._ApplicationDate = ApplicationDate;
            this.enApplicationTypeID = ApplicationType;
            this.Fees = PaidFees;
            this._enApplicationStatus = ApplicationStatus;  
            this._LastStatusDate = LastStatusDate;   
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }

        //public void SetStatus(enApplicationStatus enApplicationStatus1)
        //{
        //    _enApplicationStatus = enApplicationStatus1;
        //    _LastStatusDate = DateTime.Now;
        //}

        public static clsApplication FindBaseApplicationByID(int ApplicationID)
        {
            int ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            short Status = -1;
            DateTime ApplicationDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;
            float PaidFees = 0; 

            if (clsApplicationData.FindApplicationByAppID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID
                , ref Status, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, (clsApplicationType.enApplicationTypes)ApplicationTypeID,
                   (enApplicationStatus)Status, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool AddNewApplication()
        {
            this._ApplicationID = clsApplicationData.AddNewApplication(_ApplicantPersonID, DateTime.Now, (int)enApplicationTypeID, (int)enApplicationStatus1,
                LastStatusDate, Fees, CreatedByUserID);

            return _ApplicationID != -1;
        }

        bool UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, (int)this.enApplicationTypeID
                 , (int)this.enApplicationStatus1, this.LastStatusDate, this.Fees, this.CreatedByUserID);
        }



        public virtual bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;   
                    }

                case enMode.Update:
                    return UpdateApplication();

                default:
                    return false;
            }
        }

        public bool Cancel()
        {
            if (this._enApplicationStatus == enApplicationStatus.New)
            {
                this._enApplicationStatus = enApplicationStatus.Canceled;
                this._LastStatusDate = DateTime.Now;
                return clsApplicationData.UpdateStatus(this.ApplicationID, (short)enApplicationStatus.Canceled);
           
            }
            else
                return false;
               
           
        }

        public bool SetCompleted()
        {
            if (this._enApplicationStatus == enApplicationStatus.New)
            {
                this._enApplicationStatus = enApplicationStatus.Completed;
                this._LastStatusDate = DateTime.Now;
                return clsApplicationData.UpdateStatus(this.ApplicationID, (short)enApplicationStatus.Completed);
            }
            else
                return false;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID); 
        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

    }
}
