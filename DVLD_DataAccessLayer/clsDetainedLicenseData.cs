using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicenseData
    {
        public static bool FindDetainedLicenseByDetainID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees
           , ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from DetainedLicenses Where DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                   
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToSingle((Reader["FineFees"]));
                    IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    ReleasedByUserID = (Reader["ReleasedByUserID"] == DBNull.Value) ? -1 : (int)Reader["ReleasedByUserID"];
                    ReleaseDate = (Reader["ReleaseDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)Reader["ReleaseDate"];
                    ReleaseApplicationID = (Reader["ReleaseApplicationID"] == DBNull.Value) ? -1 : (int)Reader["ReleaseApplicationID"];


                    IsFound = true;

                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();


            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();

            }

            return IsFound;
        }

        public static bool FindDetainedLicenseByLicenseID( int LicenseID, ref int DetainID,  ref DateTime DetainDate, ref float FineFees
          , ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select top 1 * from DetainedLicenses Where LicenseID = @LicenseID And IsReleased = 0 order by DetainID desc";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToSingle((Reader["FineFees"]));
                    IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    ReleasedByUserID = (Reader["ReleasedByUserID"] == DBNull.Value) ? -1 : (int)Reader["ReleasedByUserID"];
                    ReleaseDate = (Reader["ReleasedByUserID"] == DBNull.Value) ? DateTime.MinValue : (DateTime)Reader["ReleaseDate"];
                    ReleaseApplicationID = (Reader["ReleaseApplicationID"] == DBNull.Value) ? -1 : (int)Reader["ReleaseApplicationID"];



                 

                    IsFound = true;

                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();


            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();

            }

            return IsFound;
        }



        public static int AddNewDetainedLicense( int LicenseID, DateTime DetainDate, float FineFees
           , int CreatedByUserID)
        {
            int NewDetainID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into DetainedLicenses  (LicenseID,
                               DetainDate,
                               FineFees,
                               CreatedByUserID,
                               IsReleased
                               )
                              Values (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
          

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewDetainID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return NewDetainID;

        }

        public static bool ReleaseDetainedLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update DetainedLicenses 
                              Set IsReleased = 1, ReleaseDate= @ReleaseDate, ReleasedByUserID = @ReleasedByUserID , ReleaseApplicationID = @ReleaseApplicationID

                              Where DetainID = @DetainID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return AffectedRows > 0;
        }
        public static bool UpdateDetainedLicense(int DetainID,  int LicenseID,  DateTime DetainDate,  float FineFees
           ,  int CreatedByUserID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update DetainedLicenses 
                              Set LicenseID = @LicenseID, DetainDate= @DetainDate, FineFees= @FineFees, 
                              CreatedByUserID= @CreatedByUserID
                              Where DetainID = @DetainID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
    

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return AffectedRows > 0;

        }


        public static bool DeleteDetainedLicense(int DetainID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From DetainedLicenses Where DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);



            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return AffectedRows > 0;
        }


        public static bool IsDetainedLicenseExistByDetainID(int DetainID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from DetainedLicenses Where DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", DetainID);

            object Result = null;

            try
            {
                Connection.Open();
                Result = Command.ExecuteScalar();


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return Result != null;
        }

       

        public static bool IsLicenseDetained(int LicenseID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from DetainedLicenses Where LicenseID = @LicenseID And IsReleased = 0";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            object Result = null;

            try
            {
                Connection.Open();
                Result = Command.ExecuteScalar();


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return Result != null;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * from DetainedLicenses_View order by IsReleased, DetainID ; ";

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
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return dt;

        }
    }
}
