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
    public class clsCountry
    {
       
        public int ID {  get; set; }    
        public string CountryName {  get; set; }    

        clsCountry()
        {
            ID = -1;
            CountryName = "";
        }

        clsCountry(int ID,  string CountryName)
        {
            this.ID = ID;   
            this.CountryName = CountryName;
        }


        //public static string FindCountryByID(int CountryID)
        //{
        //    string CountryName = "";

        //    clsCountryDataAccess.FindCountryByID(CountryID, ref CountryName);
        //    return CountryName; 
            
        //}

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryDataAccess.FindCountryByID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);  
            }
            else
            {
                return null;
            }

               
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryDataAccess.FindCountryByName(CountryName,ref CountryID))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }


        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
      


    }
}
