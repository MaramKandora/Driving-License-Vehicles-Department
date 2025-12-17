using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class clsTestTypesDataAccess
    {
        public static bool FindTestTypeUsingID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref float Fees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from TestTypes Where TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestTypeTitle = Reader["TestTypeTitle"].ToString();
                    TestTypeDescription = Reader["TestTypeDescription"].ToString();
                    Fees = Convert.ToSingle(Reader["TestTypeFees"]);

                    IsFound = true;
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

        public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into TestTypes 
                            Values (@TestTypeTitle , @TestTypeDescription , @TestTypeFees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch
            {
               

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;
        }
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float Fees)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update TestTypes 
                              Set TestTypeTitle = @TestTypeTitle,TestTypeDescription= @TestTypeDescription, TestTypeFees = @TestTypeFees
                              Where  TestTypeID = @TestTypeID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", Fees);


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



        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * From TestTypes order by TestTypeTitle";

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
