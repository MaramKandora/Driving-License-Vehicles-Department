using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassesData
    {
        public static bool FindLicenseClassByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
           ref short MinimumAllowedAge, ref short DefaultValidityLength, ref float ClassFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from LicenseClasses Where LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ClassName = Reader["ClassName"].ToString();
                    ClassDescription = Reader["ClassDescription"].ToString();

                    MinimumAllowedAge = Convert.ToInt16(Reader["MinimumAllowedAge"]) ;

                    DefaultValidityLength = Convert.ToInt16(Reader["DefaultValidityLength"]);

                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);

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
        public static int AddNewLicenseClass( string ClassName,  string ClassDescription,
            short MinimumAllowedAge, short DefaultValidityLength,  float ClassFees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into LicenseClasses
                            Values (@ClassName, @ClassDescription , @MinimumAllowedAge,@DefaultValidityLength,@ClassFees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);

            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);

            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);

            command.Parameters.AddWithValue("@ClassFees", ClassFees);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch 
            {

            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;
        }
        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            short MinimumAllowedAge, short DefaultValidityLength, float ClassFees)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update LicenseClasses 
                              Set ClassName = @ClassName, ClassDescription = @ClassDescription , MinimumAllowedAge =@MinimumAllowedAge,
                              DefaultValidityLength =@DefaultValidityLength , ClassFees = @ClassFees
                              Where  LicenseClassID = @LicenseClassID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@ClassName", ClassName);
            Command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            Command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);

            Command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);

            Command.Parameters.AddWithValue("@ClassFees", ClassFees);


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

        public static bool DoesPersonAlreadyHaveApplicationFprLicenseClass(int PersonID, int LicenseClassID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Select Found = 1 from LocalDrivingLicenseApplicationsView_Mine Where ApplicantPersonID = @PersonID And
                             LicenseClassID= @LicenseClassID And ApplicationStatus in (1 , 3)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * From LicenseClasses order by ClassName";

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

