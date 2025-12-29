using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool FindLocalLicenseApplicationByLDLAppID(int LocalDrivingLicenseApplicationID,ref int ApplicationID,ref int LicenseClassID )
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    

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

        public static bool FindLocalLicenseApplicationByAppID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from LocalDrivingLicenseApplications Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];


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
        public static int AddNewLocalDrivingLicenseApplication( int ApplicationID, int LicenseClassID )
        {
            int NewPersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into LocalDrivingLicenseApplications 
                              Values (@ApplicationID, @LicenseClassID);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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


        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update LocalDrivingLicenseApplications 
                              Set ApplicationID = @ApplicationID, LicenseClassID= @LicenseClassID
                              Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



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


        public static bool DeleteLocalDrivingLicenseApplicationApplication(int LDLApplicationID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);



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


        public static bool IsLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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

        public static int GetActiveTestAppointmentID(int LDLAppID, int TestTypeID)
        {
            int FoundAppointmentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"select TestAppointmentID from TestAppointments where TestTypeID = @TestTypeID 
                           And LocalDrivingLicenseApplicationID = @LDLAppID And IsLocked = 0;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            object Result = null;
            try
            {
                Connection.Open();
                Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    FoundAppointmentID = ID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return FoundAppointmentID;


        }

        public static int GetTrialsForTestType(int LDLAppID, int TestTypeID)
        {


            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"select Count(*) from TestAppointmentsView_Mine where TestTypeID = @TestTypeID 
                           And LocalDrivingLicenseApplicationID = @LDLAppID And IsLocked=1;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
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

            return Result != null ? (int)Result : -1;
        }

        public static bool IsTestForFirstTime(int LDLAppID, int TestTypeID)
        {


            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"select Found = 1 from TestAppointments where TestTypeID = @TestTypeID 
                           And LocalDrivingLicenseApplicationID = @LDLAppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
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

            return Result == null;
        }


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT distinct LocalDrivingLicenseApplicationsView_Mine.LocalDrivingLicenseApplicationID, 
                            LocalDrivingLicenseApplicationsView_Mine.ClassName, LocalDrivingLicenseApplicationsView_Mine.ApplicantPersonNationalNo
                            ,LocalDrivingLicenseApplicationsView_Mine.ApplicantPersonFullName, LocalDrivingLicenseApplicationsView_Mine.ApplicationDate, 
                            (select Count(TestResult) from TestAppointmentsView_Mine where 
                            TestAppointmentsView_Mine.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationsView_Mine.LocalDrivingLicenseApplicationID
                            And TestAppointmentsView_Mine.TestResult=1) as PassedTests
                            , ApplicationStatus = 
                            Case
                            When LocalDrivingLicenseApplicationsView_Mine.ApplicationStatus = 1 then 'New'
                            When LocalDrivingLicenseApplicationsView_Mine.ApplicationStatus = 2 then 'Canceled'
                            When LocalDrivingLicenseApplicationsView_Mine.ApplicationStatus = 3 then 'Completed'
                            End
                            from LocalDrivingLicenseApplicationsView_Mine left join TestAppointmentsView_Mine on 
                            LocalDrivingLicenseApplicationsView_Mine.LocalDrivingLicenseApplicationID = TestAppointmentsView_Mine.LocalDrivingLicenseApplicationID
                            Order By ApplicationDate Desc";

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
