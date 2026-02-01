using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DVLD_DataAccessLayer
{
    public class clsCountryDataAccess
    {
        public static bool FindCountryByID(int CountryID, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.GetConnectionString());

            string Query = $"Select * from Countries Where CountryID = @CountryID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    CountryName = Reader["CountryName"].ToString();

                    IsFound = true;
                }

                Reader.Close();

               
            }
            catch (Exception ex) 
            {
               clsLogger.LogError(ex);

                IsFound = false;
            }
            finally
            {
                Connection.Close();

            }

            return IsFound;
        }


        public static bool FindCountryByName(string CountryName, ref int CountryID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.GetConnectionString());

            string Query = $"Select * from Countries Where CountryName = @CountryName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    CountryID = (int) Reader["CountryID"];

                    IsFound = true;
                }

                Reader.Close();


            }
            catch (Exception ex)
            {
               clsLogger.LogError(ex);

                IsFound = false;
            }
            finally
            {
                Connection.Close();

            }

            return IsFound;
        }


        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.GetConnectionString());

            string Query = $"Select * From Countries";

            SqlCommand Command = new SqlCommand(Query, Connection);



            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);

                }

                Reader.Close();
            }
            catch (Exception ex) 
            {
               clsLogger.LogError(ex);

            }
            finally
            {
                Connection.Close();

            }

            return dt;
        }

      


       
    }
}
