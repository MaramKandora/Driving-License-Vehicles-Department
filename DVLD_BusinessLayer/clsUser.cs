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
        public int PersonID { get; set; }   

        public clsPerson PersonInfo {  get; set; }  
        public string UserName { get; set; }

        string _Password;

        int _EncryptionKey = 4;
        public string Password
        {
            get
            {
                return clsGlobal.DecryptText(_Password, _EncryptionKey);
            }

            set
            {
                _Password = clsGlobal.EncryptText(_Password, _EncryptionKey);
            }
        }
        public bool IsActive { get; set; }  

        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;


        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            PersonInfo = null;
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
            PersonInfo = clsPerson.FindPerson(PersonID);

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

        static public clsUser FindUser(string UserName)
        {

            string Password = "";
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUserDataAccess.FindUserByUserName(ref UserName, ref UserID, ref PersonID, ref Password, ref IsActive)) 
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
