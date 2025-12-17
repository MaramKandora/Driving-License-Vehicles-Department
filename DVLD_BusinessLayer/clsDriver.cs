using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsDriver
    {
        int _DriverID;
        public int DriverID { get { return _DriverID; } }
        int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }

            set
            {
                _PersonID = value;
                if (value == -1)
                {
                    _PersonInfo = null;
                    return;
                }

                _PersonInfo = clsPerson.FindPerson(_PersonID);
                if (PersonInfo == null)
                    _PersonID = -1;
            }
        }

        clsPerson _PersonInfo;
        public clsPerson PersonInfo { get { return _PersonInfo; } }


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

        DateTime _CreationDate;
        public DateTime CreationDate { get { return _CreationDate; }}

        enum enMode { AddNew, Update}
        enMode _Mode;
        clsDriver()
        {
            PersonID = -1;
            CreatedByUserID = -1;
            _CreationDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreationDate)
        {
            this._DriverID = DriverID;
            this._PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this._CreationDate = CreationDate;

            _Mode = enMode.Update;


        }
        static public clsDriver FindDriver(int DriverID)
        {

            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreationDate = DateTime.Now;

            if (clsDriverData.FindDriverByID(DriverID,ref PersonID,ref CreatedByUserID,ref CreationDate))
            {
                return new clsDriver(DriverID,PersonID,CreatedByUserID,CreationDate);

            }
            else
            {
                return null;
            }

        }

        public static bool IsDriverExist(int DriverID)
        {
            return clsDriverData.IsDriverExist(DriverID);
        }

      
        bool AddNewDriver()
        {


            this._DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreationDate);

            return this.DriverID != -1;
        }

        bool UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreationDate);
        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsUserDataAccess.DeleteUser(DriverID);
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewDriver())
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
                        return UpdateDriver();
                    }

                default:
                    return false;
            }

        }

        public static DataTable GetAllDrivers()

        {
            return clsDriverData.GetAllDrivers();
        }


    }
}
