using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using static DVLD_DataAccessLayer.clsPersonDataAccess;

namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public int PersonID { get; set; }  
        public string NationalNo { get; set; }  

        public string FirstName { get; set; }   
        public string SecondName { get; set; } 
        public string ThirdName { get; set; }   
        public string LastName { get; set; } 
        public DateTime DateOfBirth { get; set; }  
        
        public enGender Gender { get; set; }
        public string Address { get; set; } 
        public string Phone {  get; set; }  
        public string Email { get; set; }   
        public int NationalityCountryID { get; set; }   
        public string ImagePath { get; set; }

        public clsCountry CountryInfo;

        private string _FullName;
        public string FullName
        {
            get {  return _FullName; }  
        }

        public enum enGender { Male =0, Female=1 };

        enum enMode { AddNew, Update}
        enMode _Mode = enMode.AddNew;

        
        public clsPerson()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            CountryInfo = null;
            ImagePath = "";
            _FullName = "";

            _Mode = enMode.AddNew;
            
        }

       private clsPerson(int PersonID,string NationalNo, string FirstName , string SecondName , string ThirdName , string LastName , DateTime DateOfBirth,
                 clsPerson.enGender Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath )
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName; 
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            CountryInfo = clsCountry.Find(NationalityCountryID);
            this.ImagePath = ImagePath;

            if (ThirdName != "")
                _FullName = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            else
                _FullName = FirstName + " " + SecondName + " " + LastName;

            _Mode = enMode.Update;
        }

        static public clsPerson FindPerson( int PersonID )
        {
            
            string NationalNo = default, FirstName = default, SecondName = default, ThirdName = default, LastName = default, Address = default
                , Phone = default, Email = default, ImagePath = default;
            int NationalityCountryID = -1;
            DateTime DateOfBirth = default;
            short Gender = -1 ;

            if (clsPersonDataAccess.FindPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
               ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath)) 
            {
              return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,(enGender) Gender
                    , Address, Phone, Email, NationalityCountryID,ImagePath);

            }
            else
            {
                return null;
            }

        }

        static public clsPerson FindPerson(string NationalNo)
        {

            string  FirstName = default, SecondName = default, ThirdName = default, LastName = default, Address = default
                , Phone = default, Email = default, ImagePath = default;
            int NationalityCountryID = -1, PersonID = -1 ;
            DateTime DateOfBirth = default;
            short Gender = -1 ;

            if (clsPersonDataAccess.FindPersonNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
               ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGender)Gender
                      , Address, Phone, Email, NationalityCountryID, ImagePath);

            }
            else
            {
                return null;
            }

        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonDataAccess.IsPersonExist(NationalNo);
        }

         bool AddNewPerson()
        {
           this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,(short)this.Gender
                    , this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            if (PersonID != -1)
            {
                if (ThirdName != "")
                    _FullName = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
                else
                    _FullName = FirstName + " " + SecondName + " " + LastName;

                return true;
            }
            else
            {
                return false;
            }

        }

         bool UpdatePerson()
        {
            if (this.ThirdName != "")
                _FullName = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            else
                _FullName = FirstName + " " + SecondName + " " + LastName;

            return clsPersonDataAccess.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, (short)this.Gender
                    , this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

           
        }

        public static bool DeletePerson(int personID)
        {
            return clsPersonDataAccess.DeletePerson(personID);
        }


        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if(AddNewPerson())
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
                        return UpdatePerson();
                    }

                default:
                    return false;
            }

        }

        public static DataTable GetAllPeople()
        
        {
            return clsPersonDataAccess.GetAllPeople();  
        }

       

    }
}
