using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseData
    {
        public static bool FindInternationalLicenseByInternationalLicenseID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
            ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                   IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static bool FindInternationalLicenseByLDLAppID( int IssuedUsingLocalLicenseID, ref int ApplicationID, ref int InternationalLicenseID, ref int DriverID,  ref DateTime IssueDate
          , ref DateTime ExpirationDate,  ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from InternationalLicenses Where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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





        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate
          , DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int NewInternationalLicenseID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update InternationalLicenses Set IsActive = 0
                              Where DriverID = @DriverID;
                              Insert Into InternationalLicenses 
                              Values (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate,
                              @IsActive, @CreatedByUserID);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewInternationalLicenseID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return NewInternationalLicenseID;

        }


        public static bool UpdateLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate
          , DateTime ExpirationDate, bool IsActive,int CreatedByUserID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update InternationalLicenses 
                              Set ApplicationID = @ApplicationID, DriverID= @DriverID, IssuedUsingLocalLicenseID= @IssuedUsingLocalLicenseID, 
                              IssueDate= @IssueDate, ExpirationDate= @ExpirationDate,
                              IsActive= @IsActive, CreatedByUserID= @CreatedByUserID
                              Where InternationalLicenseID = @InternationalLicenseID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
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


        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);



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


        public static bool IsLicenseExistByInternationalLicenseID(int InternationalLicenseID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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

        //public static int GetInternationalLicenseIDUsingApplicationID(int ApplicationID)
        //{
        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


        //    string Query = $"Select InternationalLicenseID from InternationalLicenses Where ApplicationID = @ApplicationID";

        //    SqlCommand Command = new SqlCommand(Query, Connection);

        //    Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        //    object Result = null;

        //    try
        //    {
        //        Connection.Open();
        //        Result = Command.ExecuteScalar();


        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        Connection.Close();

        //    }

        //    return Result != null ? (int)Result : -1;
        //}

        public static DataTable GetAllInternationalLicensesForDriver(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID, IssueDate,
                            ExpirationDate, IsActive from InternationalLicenses
                            Where DriverID = @DriverID order by  ExpirationDate Desc;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);


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

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select InternationalLicenseID, ApplicationID,DriverID, IssuedUsingLocalLicenseID, IssueDate,
                            ExpirationDate, IsActive from InternationalLicenses order by IsActive, IssueDate Desc;";

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

        public static int GetActiveInternationalLicenseID(int DriverID)
        {
            int LicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Select Top 1 InternationalLicenseID from InternationalLicenses Where DriverID = @DriverID And IsActive = 1
                              And GetDate() Between IssueDate And ExpirationDate
                              Order by ExpirationDate";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);

            object Result = null;

            try
            {
                Connection.Open();
                Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int FoundLicenseID))
                {
                    LicenseID = FoundLicenseID; 
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return LicenseID;
        }
    }
}
