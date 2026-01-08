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
    public class clsDetainedLicense
    {

        int _DetainID;
        public int DetainID { get { return _DetainID; } }

        int _LicenseID;
        public int LicenseID
        {
            get { return _LicenseID; }
            set
            {
                _LicenseID = value;
                if (value == -1)
                {
                    _LicenseInfo = null;
                    return;
                }


                _LicenseInfo = clsLicense.FindLicenseByLicenseID(value);
                if (LicenseInfo == null)
                    _LicenseID = -1;
            }
        }

        clsLicense _LicenseInfo;
        public clsLicense LicenseInfo { get { return _LicenseInfo; } }


        DateTime _DetainDate;
        public DateTime DetainDate { get { return _DetainDate; } }

        public float FineFees { get; set; }
        public bool IsReleased { get; set; }

        DateTime _ReleaseDate;
        public DateTime ReleaseDate { get { return _ReleaseDate; } }

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


        int _ReleasedByUserID;
        public int ReleasedByUserID
        {
            get { return _ReleasedByUserID; }
            set
            {
                _ReleasedByUserID = value;
                if (value == -1)
                {
                    _ReleasedByUserInfo = null;
                    return;
                }

                _ReleasedByUserInfo = clsUser.FindUser(_ReleasedByUserID);
                if (ReleasedByUserInfo == null)
                    _ReleasedByUserID = -1;
            }
        }

        clsUser _ReleasedByUserInfo;
        public clsUser ReleasedByUserInfo { get { return _ReleasedByUserInfo; } }


        int _ReleaseReleaseApplicationID;
        public int ReleaseApplicationID
        {
            get { return _ReleaseReleaseApplicationID; }
            set
            {
                _ReleaseReleaseApplicationID = value;
                if (value == -1)
                {
                    _ReleaseApplicationInfo = null;
                    return;
                }


                _ReleaseApplicationInfo = clsApplication.FindBaseApplicationByID(value);
                if (ReleaseApplicationInfo == null)
                    _ReleaseReleaseApplicationID = -1;
            }
        }

        clsApplication _ReleaseApplicationInfo;
        public clsApplication ReleaseApplicationInfo { get { return _ReleaseApplicationInfo; } }



        enum enMode { AddNew, Update }
        enMode _Mode;

        public clsDetainedLicense()
        {
            _DetainID = -1;
            LicenseID = -1;
            _DetainDate = DateTime.Now;
            _ReleaseDate = DateTime.Now;
            FineFees = 0;
            IsReleased = false;
            CreatedByUserID = -1;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;  

            _Mode = enMode.AddNew;

        }

        clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased
          , DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this._DetainID = DetainID;
            this.LicenseID = LicenseID;
            this._DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this._ReleaseDate = ReleaseDate;
            this.ReleasedByUserID= ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            _Mode = enMode.Update;
        }


        static public clsDetainedLicense FindDetainedLicenseByDetainID(int DetainID)
        {

            int LicenseID = -1, ReleasedByUserID = -1, CreatedByUserID = -1, ReleaseApplicationID = -1;

            DateTime DetainDate = DateTime.Now;
            DateTime ReleaseDate = DateTime.Now;
            float FineFees = 0;
            bool IsReleased = false;


            if (clsDetainedLicenseData.FindDetainedLicenseByDetainID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
               ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID)) 
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            }
            else
            {
                return null;
            }

        }

        static public clsDetainedLicense FindDetainedLicenseByLicenseID(int LicenseID)
        {

            int DetainID = -1, ReleasedByUserID = -1, CreatedByUserID = -1, ReleaseApplicationID = -1;

            DateTime DetainDate = DateTime.Now;
            DateTime ReleaseDate = DateTime.Now;
            float FineFees = 0;
            bool IsReleased = false;


            if (clsDetainedLicenseData.FindDetainedLicenseByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID,
               ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            }
            else
            {
                return null;
            }

        }

        public static bool IsDetainedLicenseExistByDetainID(int DetainID)
        {
            return clsDetainedLicense.IsDetainedLicenseExistByDetainID(DetainID);
        }

        public static bool IsDetainedLicenseExistByReleaseApplicationID(int ReleaseApplication)
        {
            return clsDetainedLicense.IsDetainedLicenseExistByReleaseApplicationID(ReleaseApplication);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        bool AddNewDetainedLicense()
        {
            this._DetainDate = DateTime.Now;
            
            
            this._DetainID = clsDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);  

            return this._DetainID != -1;
        }

        bool UpdateLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
        }

        bool ReleaseDetainedLicense(int ReleaseApplicationID, int ReleasedByUserID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleaseApplicationID);
        }

        public static bool DeleteDetainedLicense(int DetainID)
        {
            return clsDetainedLicenseData.DeleteDetainedLicense(DetainID);
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewDetainedLicense())
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

        public static DataTable GetAllLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public bool Release(int ReleasedByUserID)
        {
            if (this.DetainID == -1 || this.IsReleased == true) 
                return false;

            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.LicenseInfo.DriverInfo.PersonID;
            Application.CreatedByUserID = ReleasedByUserID;
            Application.enApplicationStatusID = clsApplication.enApplicationStatus.Completed;
            Application.enApplicationTypeID = clsApplicationType.enApplicationTypes.ReleaseDetainedL;
            Application.Fees = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReleaseDetainedL).ApplicationFees;

            if (!Application.Save())
                return false;
            this.ReleaseApplicationID = Application.ApplicationID;

            return this.ReleaseDetainedLicense(this.ReleaseApplicationID, ReleasedByUserID);
            

        }

    }
}
