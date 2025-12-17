using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentData
    {
        public static bool FindTestAppointmentByID(int TestAppointmentID,ref int TestTypeID, ref int LocalDrivingLicenseApplicationID
           , ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked,
           ref int RetakeTestApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from TestAppointments Where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID =(int) Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(Reader["LastName"]) ;
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    RetakeTestApplicationID = (Reader["RetakeTestApplicationID"] == DBNull.Value) ? -1 : (int)Reader["RetakeTestApplicationID"];

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


        public static bool FindTestAppointmentByRetakeTestApplicationID(int RetakeTestApplicationID,ref int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID
         , ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from TestAppointments Where RetakeTestApplicationID = @RetakeTestApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(Reader["LastName"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);

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

        

        public static int AddNewTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID
           , DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int NewTestAppointmentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into TestAppointments 
                              Values (@TestAppointmentID, @TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate,
                              @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);


            if (RetakeTestApplicationID != -1) 
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

           


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewTestAppointmentID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return NewTestAppointmentID;

        }


        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID
           , DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update TestAppointments
                              Set TestTypeID = @TestTypeID, LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID, 
                              AppointmentDate= @AppointmentDate, PaidFees= @PaidFees, CreatedByUserID= @CreatedByUserID ,
                              IsLocked= @IsLocked, RetakeTestApplicationID= @RetakeTestApplicationID
                              Where TestAppointmentID = @TestAppointmentID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);


            if (RetakeTestApplicationID != -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);


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


        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From TestAppointments Where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);



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


        public static bool IsTestAppointmentExistByTestAppointmentID(int TestAppointmentID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from TestAppointments Where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static bool IsTestAppointmentExistByRetakeTestID(int RetakeTestApplicationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from TestAppointments Where RetakeTestApplicationID = @RetakeTestApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

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
       

        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //to do :finish GetAllTestAppoinmtents Query
            string Query = @"SELECT ";

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
