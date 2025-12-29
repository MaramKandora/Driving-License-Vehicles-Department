using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLD_DataAccessLayer;
using static DVLD_BusinessLayer.clsLicenseClass;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        int _LDLApplicationID;
        public int LDLApplicationID { get { return _LDLApplicationID; } }


        clsLicenseClass.enLicenseClasses _enLicenseClassID;
        public clsLicenseClass.enLicenseClasses LicenseClassID
        {
            get { return _enLicenseClassID; }
            set
            {
                _enLicenseClassID = value;
                _LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(_enLicenseClassID);
                if (_LicenseClassInfo == null)
                    _enLicenseClassID = enLicenseClasses.Ordinary;
            }
        }
        clsLicenseClass _LicenseClassInfo;
        public clsLicenseClass LicenseClassInfo { get { return _LicenseClassInfo; } }

        enum enMode { AddNew,Update}
        enMode _Mode;
        public clsLocalDrivingLicenseApplication() : base()
        {
            this._LDLApplicationID = -1;
            this.LicenseClassID = clsLicenseClass.enLicenseClasses.Ordinary;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int LDLApplicationID, int LicenseClassID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, clsApplicationType.enApplicationTypes ApplicationType,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID) : base(ApplicationID, ApplicantPersonID,
                ApplicationDate, ApplicationType, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this._LDLApplicationID = LDLApplicationID;
            this.LicenseClassID =(clsLicenseClass.enLicenseClasses) LicenseClassID;   
            
            _Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByLDLAppID(int LDLApplicationID)
        {
            int ApplicationID=-1, LicenseClassID=-1;    
            

            if (clsLocalDrivingLicenseApplicationData.FindLocalLicenseApplicationByLDLAppID(LDLApplicationID,ref ApplicationID,ref LicenseClassID))
            {
                clsApplication BaseApplication = clsApplication.FindBaseApplicationByID(ApplicationID);

                if ( BaseApplication != null) 
                {
                    return new clsLocalDrivingLicenseApplication(LDLApplicationID, LicenseClassID, ApplicationID, BaseApplication.ApplicantPersonID
                        , BaseApplication.ApplicationDate, BaseApplication.enApplicationTypeID, BaseApplication.enApplicationStatusID
                        , BaseApplication.LastStatusDate, BaseApplication.Fees, BaseApplication.CreatedByUserID);
                }
                else
                {
                    return null;
                }
            }
               
                    
            else
            {
                return null;
            }
        }


        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByAppID(int BaseApplicationID)
        {
            int LDLApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.FindLocalLicenseApplicationByAppID(BaseApplicationID, ref LDLApplicationID, ref LicenseClassID))
            {
                clsApplication BaseApplication = clsApplication.FindBaseApplicationByID(BaseApplicationID);

                if (BaseApplication != null)
                {
                    return new clsLocalDrivingLicenseApplication(LDLApplicationID, LicenseClassID, BaseApplicationID, BaseApplication.ApplicantPersonID
                        , BaseApplication.ApplicationDate, BaseApplication.enApplicationTypeID, BaseApplication.enApplicationStatusID
                        , BaseApplication.LastStatusDate, BaseApplication.Fees, BaseApplication.CreatedByUserID);
                }
                else
                {
                    return null;
                }
            }


            else
            {
                return null;
            }
        }
       
        private bool AddNewLocalDrivingLicenseApplication()
        {
            
            this._LDLApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID,(int) this.LicenseClassID);
            return LDLApplicationID != -1;

        }

        private bool UpdateLocalDrivingLicenseApplication()
        {
          
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LDLApplicationID,this.ApplicationID,(int)this.LicenseClassID); 
        }
        public override bool Save()
        {
            if (!base.Save())
            {
                return false;

            }

 
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (AddNewLocalDrivingLicenseApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }


        public static bool DeleteLocalDrivingLicenseApplication(int LDLAppID)
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByLDLAppID(LDLAppID);

            if (LDLApp == null)
            {
                return false;
            }

            if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplicationApplication(LDLAppID))
            {
                return clsApplication.DeleteApplication(LDLApp.ApplicationID);
            }
            else
            {
                return false;
            }
            
        }



        public bool IsTestForFirstTime( clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.IsTestForFirstTime(this.LDLApplicationID, (int)TestType);
        }

        public bool IsLicenseIssued()
        {
            return clsLicense.IsLicenseExistByApplicationID(this.ApplicationID);    
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public bool IsTestTypePassed(clsTestType.enTestType TestType)
        {
            return clsTest.IsTestPassed(this.LDLApplicationID, TestType);
        }

        public int GetTrialsOfTestType(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.GetTrialsForTestType(this.LDLApplicationID, (int)TestType);
        }

        public bool IsThereActiveTestForTestType( clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.GetActiveTestAppointmentID(this.LDLApplicationID,(int)TestType) != -1;
        }

    }



}

