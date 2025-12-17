using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public enum enLicenseClasses {  SmallMotorCycle =1 , HeavyMotorcycle ,Ordinary, Commercial, Agricultural, smallAndMediumBus, TruckAndHeavyVehicle }
        enLicenseClasses _enLicenseClassID;
        public enLicenseClasses enLicenseClassID { get { return _enLicenseClassID; } }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }    
        public short MinimumAllowedAge { get; set; }    
        public short DefaultValidityLength { get; set; } 
        
        public float Fees {  get; set; }    

        enum enMode { AddNew, Update };
        enMode _Mode;
        public clsLicenseClass()
        {
            this._enLicenseClassID = enLicenseClasses.Ordinary;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.Fees = 0;

            _Mode = enMode.AddNew;
        }
        private clsLicenseClass(enLicenseClasses enLicenseClass, string ClassName,string ClassDescription, short MinimumAllowedAge,
            short ValidityLength, float ClassFees)
        {
           this._enLicenseClassID = enLicenseClass;
            this.ClassName= ClassName;  
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge= MinimumAllowedAge;  
            this.DefaultValidityLength= ValidityLength; 
            this.Fees= ClassFees;   

            _Mode = enMode.Update;
        }
        public static clsLicenseClass FindLicenseClassByID(enLicenseClasses LicenseClass)
        {
            string ClassName = "", Description="";
            short MinimumAllowedAge = 0, ValidityLength = 0;
            float Fees = 0;
            if (clsLicenseClassesData.FindLicenseClassByID((int)LicenseClass, ref ClassName, ref Description, ref MinimumAllowedAge
                , ref ValidityLength, ref Fees))
            {
                return new clsLicenseClass(LicenseClass, ClassName, Description , MinimumAllowedAge, ValidityLength , Fees);
            }
            else
            {
                return null;
            }
        }

        private bool AddNewLicenseClass()
        {

            if (Enum.TryParse(clsLicenseClassesData.AddNewLicenseClass(this.ClassName, this.ClassDescription
                , this.MinimumAllowedAge, this.DefaultValidityLength, this.Fees).ToString(), out enLicenseClasses enLicenseClass1)) 
            {
                this._enLicenseClassID = enLicenseClass1;
                return true;
            }
            else
            {
                this._enLicenseClassID = enLicenseClasses.Ordinary;
                return false;
            }

        }

        private bool UpdateLicenseClass()
        {
            return clsLicenseClassesData.UpdateLicenseClass((int)enLicenseClassID,ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength
                , Fees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (AddNewLicenseClass())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return UpdateLicenseClass();

                default:
                    return false;
            }
        }


        public static bool DoesPersonAlreadyHaveApplicationForLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsLicenseClassesData.DoesPersonAlreadyHaveApplicationFprLicenseClass(PersonID, LicenseClassID);
        }

        public static bool CheckAgeValidityForLicenseClass(DateTime DateOfBirth, clsLicenseClass.enLicenseClasses LicenseClassID)
        {
            clsLicenseClass LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(LicenseClassID);
            DateTime MinimumAllowedDateOfBirth = DateTime.Now.AddYears(-LicenseClassInfo.MinimumAllowedAge);

            return DateOfBirth <= MinimumAllowedDateOfBirth;

        }


        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }
    }
}
