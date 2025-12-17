using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class clsUserDataAccess
    {

        public static bool FindUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from Users Where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    UserName = Reader["UserName"].ToString();
                    Password = Reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                 

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


        public static bool FindUserByUserNameAndPassword(ref string UserName, ref string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from Users Where UserName = @UserName And Password = @Password";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    UserID = (int)Reader["UserID"];
                    UserName = Reader["UserName"].ToString();
                    PersonID = (int)Reader["PersonID"];
                    Password = Reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);


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


        public static bool FindUserByPersonID( int PersonID,ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from Users Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    UserID = (int)Reader["UserID"];
                    UserName = Reader["UserName"].ToString();
                    Password = Reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);


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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int NewUserID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into Users 
                              Values (@PersonID, @UserName, @Password, @IsActive);
                              select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewUserID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }

            return NewUserID;

        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update Users 
                              Set PersonID = @PersonID, UserName= @UserName, Password= @Password, 
                              IsActive= @IsActive
                              Where UserID = @UserID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

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


        public static bool DeleteUser(int UserID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From Users Where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);



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


        public static bool IsUserExist(int UserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from Users Where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

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


        public static bool IsUserExist(string UserName)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from Users Where UserName = @UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserName", UserName);

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

        public static bool IsUserExist_ByPersonID(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from Users Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Users.UserID, Users.PersonID, 
                           FullName = People.FirstName + ' ' + People.SecondName + ' ' + IsNull(People.ThirdName,'') + People.LastName ,
                            Users.UserName, Users.IsActive From Users
                            Inner Join People on Users.PersonID= People.PersonID";

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
