using System;
using System.Collections.Generic;
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

                    if (ReleasedByUserID != -1) 
                        Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    else
                        Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

                    if (ReleaseApplicationID != -1)
                        Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    else
                        Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

                    if (ReleaseDate != null)
                        Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                    else
                        Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);


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

        public static bool FindDetainedLicenseByReleaseApplicationID( int ReleaseApplicationID,ref int DetainID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees
          , ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID )
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from DetainedLicenses Where ReleaseApplicationID = @ReleaseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToSingle((Reader["FineFees"]));
                    IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    if (ReleasedByUserID != -1)
                        Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    else
                        Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

                    if (ReleaseDate != null)
                        Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                    else
                        Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);


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
           , int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int NewDetainID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into DetainedLicenses 
                              Values (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate ,
                              @ReleasedByUserID, @ReleaseApplicationID);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


            if (ReleaseDate != null)
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            else
                Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);

            if (ReleasedByUserID != -1)
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            else
                Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

            if (ReleaseApplicationID != -1)
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            else
                Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);


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


        public static bool UpdateDetainedLicense(int DetainID,  int LicenseID,  DateTime DetainDate,  float FineFees
           ,  int CreatedByUserID,  bool IsReleased,  DateTime ReleaseDate,  int ReleasedByUserID,  int ReleaseApplicationID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update DetainedLicenses 
                              Set LicenseID = @LicenseID, DetainDate= @DetainDate, FineFees= @FineFees, 
                              CreatedByUserID= @CreatedByUserID, IsReleased= @IsReleased, ReleaseDate= @ReleaseDate ,
                              ReleasedByUserID= @ReleasedByUserID, ReleaseApplicationID= @ReleaseApplicationID
                              Where DetainID = @DetainID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
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

        public static bool IsDetainedLicenseExistByReleaseApplicationID(int ReleaseApplicationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from DetainedLicenses Where ReleaseApplicationID = @ReleaseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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

        //    public static DataTable GetAllDetainedLicenses()
        //    {
        //        DataTable dt = new DataTable();

        //        SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //        string Query = @"SELECT ";

        //        SqlCommand Command = new SqlCommand(Query, Connection);



        //        try
        //        {
        //            Connection.Open();
        //            SqlDataReader Reader = Command.ExecuteReader();

        //            if (Reader.HasRows)
        //            {
        //                dt.Load(Reader);

        //            }

        //            Reader.Close();
        //        }
        //        catch
        //        {

        //        }
        //        finally
        //        {
        //            Connection.Close();

        //        }

        //        return dt;

        //    }
    }
}
