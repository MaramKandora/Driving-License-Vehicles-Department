using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestData
    {
        public static bool FindTestByTestID(int TestID, ref int TestAppointmentID, ref bool TestResult,
           ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from Tests Where TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
                    Notes = (Reader["Notes"] == DBNull.Value) ? "" : Reader["Notes"].ToString();
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


        public static bool FindTestByAppointmentID( int TestAppointmentID, ref int TestID, ref bool TestResult,
           ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from Tests Where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestID = (int)Reader["TestID"];
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
                    Notes = (Reader["Notes"] == DBNull.Value) ? "" : Reader["Notes"].ToString();
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


        public static byte GetPassedTestsCount(int LDLAppID)
        {
            byte PassedTests = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Select Count(TestResult) from TestAppointmentsView_Mine where LocalDrivingLicenseApplicationID = @LDLAppID
                           And TestResult = 1";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int Num))
                {
                    PassedTests = (byte)Num;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return PassedTests;
        }


        public static int GetPassedTestIDForTestType(int LDLAppID, int TestTypeID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"select TestID from TestAppointmentsView_Mine where LocalDrivingLicenseApplicationID= @LDLAppID
                            And TestTypeID =@TestTypeID And TestResult =1;";

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
            // return -1 if there is no passed test
            return Result != null ? (int)Result : -1;
        }


        public static int AddNewTest(int TestID, int TestAppointmentID, bool TestResult
            , string Notes, int CreatedByUserID)
        {
            int NewTestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into Tests 
                              Values ( @TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                             
                              Update TestAppointments 
                              set IsLocked = 1 where TestAppointmentID= @TestAppointmentID
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (!string.IsNullOrWhiteSpace(Notes))
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewTestID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return NewTestID;

        }


        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult
            , string Notes, int CreatedByUserID)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update Tests 
                              Set TestAppointmentID= @TestAppointmentID, TestResult= @TestResult, 
                              Notes= @Notes, CreatedByUserID= @CreatedByUserID
                              Where TestID = @TestID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (!string.IsNullOrWhiteSpace(Notes))
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);


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


        public static bool DeleteTest(int TestID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From Tests Where TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);



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


        public static bool IsTestExistByTestID(int TestID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from Tests Where TestID = @TestID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

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


       
       

        //    public static DataTable GetAllTests()
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




        //}
    }
}
