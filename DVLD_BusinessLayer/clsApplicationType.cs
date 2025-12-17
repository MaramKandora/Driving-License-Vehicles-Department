using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {
        public enum enApplicationTypes {NewLocalLicense =1 , RenewLicense, Replacement_Lost, Replacement_Damaged, ReleaseDetainedL,NewInternationalL, RetakeTest }

        public enApplicationTypes enApplicationType1 { get; set; } 

       public string ApplicationTypeTitle { get; set; }

        public float ApplicationFees { get; set; }

        enum enMode { AddNew, Update};
        enMode _Mode;
        public clsApplicationType()
        {
            this.enApplicationType1 =enApplicationTypes.NewLocalLicense;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
            _Mode = enMode.AddNew;  
        }
        private clsApplicationType(enApplicationTypes applicationType, string applicationTypeTitle, float applicationFees)
        {
            this.enApplicationType1 = applicationType;
            this.ApplicationTypeTitle = applicationTypeTitle;   
            this.ApplicationFees = applicationFees;
            _Mode = enMode.Update;
        }
        public static clsApplicationType FindApplicationType(enApplicationTypes AppType)
        {
            string AppTypeTitle = "";
            float Fees = 0;
            if (clsApplicationTypesDataAccess.FindApplicationTypeByID((int)AppType, ref AppTypeTitle, ref Fees))
            {
               return new clsApplicationType(AppType, AppTypeTitle, Fees);
            }
            else
            {
                return null;
            }
        }

        private bool AddNewApplicationType()
        {

            if (Enum.TryParse(clsApplicationTypesDataAccess.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees).ToString(), out enApplicationTypes AppType))
            {
                this.enApplicationType1 = AppType;
                return true;
            }
            else
            {
                //this.enApplicationType1 = enApplicationTypes.NewLocalLicense;
                return false;       
            }

        }

        private bool UpdateApplicationType()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationType((int)this.enApplicationType1, this.ApplicationTypeTitle, this.ApplicationFees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (AddNewApplicationType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return UpdateApplicationType();

                default:
                    return false;
            }
        }
                    
           
        

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }

    }
}
