using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class clsApplicationData
    {
        public static bool FindApplicationByAppID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID
            , ref short ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from Applications Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate =(DateTime) Reader["ApplicationDate"];
                    ApplicationTypeID =(int) Reader["ApplicationTypeID"];
                    ApplicationStatus = Convert.ToInt16(Reader["ApplicationStatus"]) ;
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    CreatedByUserID =(int) Reader["CreatedByUserID"];
                

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


        public static int AddNewApplication( int ApplicantPersonID, DateTime ApplicationDate,  int ApplicationTypeID
            ,  int ApplicationStatus,  DateTime LastStatusDate,  float PaidFees,  int CreatedByUserID)
        {
            int NewPersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into Applications 
                              Values (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                              @LastStatusDate, @PaidFees , @CreatedByUserID);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewPersonID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return NewPersonID;

        }


        public static bool UpdateApplication(int ApplicationID ,int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID
            , int ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update Applications 
                              Set ApplicantPersonID = @ApplicantPersonID, ApplicationDate= @ApplicationDate, ApplicationTypeID= @ApplicationTypeID, 
                              ApplicationStatus= @ApplicationStatus, LastStatusDate= @LastStatusDate, PaidFees= @PaidFees ,CreatedByUserID= @CreatedByUserID

                              Where ApplicationID = @ApplicationID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);



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


        public static bool DeleteApplication(int ApplicationID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From Applications Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);



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


        public static bool DoesPersonAlreadyHaveApplication(int PersonID, int ApplicationType)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Select Found = 1 from Applications Where ApplicantPersonID = @PersonID And
                             ApplicationType= @ApplicationType And ApplicationStatus in (1 , 3)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@ApplicationType", ApplicationType);

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


        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        // public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        // {

        //     //incase the ActiveApplication ID !=-1 return true.
        //     return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        // }

        // public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        // {
        //     int ActiveApplicationID = -1;

        //     SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string query = "SELECT ActiveApplicationID=ApplicationID FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
        //     command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

        //     try
        //     {
        //         connection.Open();
        //         object result = command.ExecuteScalar();


        //         if (result != null && int.TryParse(result.ToString(), out int AppID))
        //         {
        //             ActiveApplicationID = AppID;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         return ActiveApplicationID;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return ActiveApplicationID;
        // }

        // public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        // {
        //     int ActiveApplicationID = -1;

        //     SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
        //                     From
        //                     Applications INNER JOIN
        //                     LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
        //                     WHERE ApplicantPersonID = @ApplicantPersonID 
        //                     and ApplicationTypeID=@ApplicationTypeID 
        //and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
        //                     and ApplicationStatus=1";

        //     SqlCommand command = new SqlCommand(query, connection);

        //     command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
        //     command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
        //     command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
        //     try
        //     {
        //         connection.Open();
        //         object result = command.ExecuteScalar();


        //         if (result != null && int.TryParse(result.ToString(), out int AppID))
        //         {
        //             ActiveApplicationID = AppID;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         //Console.WriteLine("Error: " + ex.Message);
        //         return ActiveApplicationID;
        //     }
        //     finally
        //     {
        //         connection.Close();
        //     }

        //     return ActiveApplicationID;
        // }


        public static bool IsApplicationExist(int ApplicationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from Applications Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

     

        //public static DataTable GetAllApplications()
        //{
        //    DataTable dt = new DataTable();

        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string Query = @"SELECT ";

        //    SqlCommand Command = new SqlCommand(Query, Connection);



        //    try
        //    {
        //        Connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();

        //        if (Reader.HasRows)
        //        {
        //            dt.Load(Reader);

        //        }

        //        Reader.Close();
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        Connection.Close();

        //    }

        //    return dt;

        //}

    }
}
