using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }

        int _PersonID;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }
            set
            {
                _PersonID = value;
                _PersonInfo = clsPerson.FindPerson(_PersonID);
                
            }
        }


        clsPerson _PersonInfo;
        public clsPerson PersonInfo { get { return _PersonInfo; } }  
        public string UserName { get; set; }

        string _Password;

        public string Password
        {
            get
            {
                return clsEncryptDecrypt.DecryptText(_Password);
            }

            set
            {
                _Password = clsEncryptDecrypt.EncryptText(value);
            }
        }
        public bool IsActive { get; set; }  

        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;


        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            _PersonInfo = null;
            UserName = "";
            _Password = "";
            IsActive = false;   

            _Mode = enMode.AddNew;

        }

        private clsUser(int UserID ,int PersonID, string UserName, string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;   
            this._Password = Password;   
            this.IsActive = IsActive;

            _Mode = enMode.Update;
        }

        static public clsUser FindUser(int UserID)
        {

            string UserName = "", Password = "" ;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserDataAccess.FindUserByID(UserID, ref PersonID,ref UserName,ref Password,ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive); 

            }
            else
            {
                return null;
            }

        }

        static public clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            Password = clsEncryptDecrypt.EncryptText(Password);

            if (clsUserDataAccess.FindUserByUserNameAndPassword(ref UserName, ref Password, ref UserID, ref PersonID, ref IsActive)) 
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            }
            else
            {
                return null;
            }

        }

        static public clsUser FindUserByPersonID(int PersonID)
        {
            string Password = "", UserName = "";
            int UserID = -1;
            bool IsActive = false;

            if (clsUserDataAccess.FindUserByPersonID(PersonID, ref UserID,ref UserName,ref Password,ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            }
            else
            {
                return null;
            }
        }

       
        public static bool IsUserExist(int UserID)
        {
            return clsUserDataAccess.IsUserExist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserDataAccess.IsUserExist(UserName);
        }

        public static bool IsUserExist_ByPersonID(int PersonID)
        {
            return clsUserDataAccess.IsUserExist_ByPersonID(PersonID);
        }

        bool AddNewUser()
        {
            

            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this._Password, this.IsActive);

            return this.UserID != -1;
        }

        bool UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, this._Password, this.IsActive);  
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewUser())
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
                        return UpdateUser();
                    }

                default:
                    return false;
            }

        }

        public static DataTable GetAllUsers()

        {
            return clsUserDataAccess.GetAllUsers();
        }


        
       

    }
}
