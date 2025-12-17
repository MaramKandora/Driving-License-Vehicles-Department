
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DataAccessLayer
{
    

     public static class clsPersonDataAccess
    {

   
        public static bool FindPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName
            , ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref string Phone,
            ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from People Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
               SqlDataReader Reader= Command.ExecuteReader();

                if (Reader.Read()) 
                {
                    NationalNo = Reader["NationalNo"].ToString();
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = (Reader["ThirdName"] == DBNull.Value) ? "" : Reader["ThirdName"].ToString();
                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = (DateTime) Reader["DateOfBirth"];
                    Gender = (short)Convert.ToInt32((Reader["Gender"]));
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = (Reader["Email"] == DBNull.Value) ? "" : Reader["Email"].ToString();
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    ImagePath = (Reader["ImagePath"] == DBNull.Value) ? "" : Reader["ImagePath"].ToString();

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


        public static bool FindPersonNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName
           , ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref string Phone,
           ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select * from People Where NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID =(int) Reader["PersonID"];
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = (Reader["ThirdName"] == DBNull.Value) ? "" : Reader["ThirdName"].ToString();
                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gender = (short)Convert.ToInt32((Reader["Gender"]));
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = (Reader["Email"] == DBNull.Value) ? "" : Reader["Email"].ToString();
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    ImagePath = (Reader["ImagePath"] == DBNull.Value) ? "" : Reader["ImagePath"].ToString();

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


        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName
            , string LastName, DateTime DateOfBirth, short Gender, string Address, string Phone,
             string Email, int NationalityCountryID, string ImagePath)
        {
            int NewPersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Insert Into People 
                              Values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth , @Gender,
                              @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                              select Scope_Identity()";
                              

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
 

            if (!string.IsNullOrWhiteSpace(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(Email))
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString(), out int InsertedID))
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


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName
            , string LastName, DateTime DateOfBirth, short Gender, string Address, string Phone,
             string Email, int NationalityCountryID, string ImagePath)
        {

            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"Update People 
                              Set NationalNo = @NationalNo, FirstName= @FirstName, SecondName= @SecondName, 
                              ThirdName= @ThirdName, LastName= @LastName, DateOfBirth= @DateOfBirth ,Gender= @Gender,
                              Address= @Address, Phone= @Phone, Email= @Email, NationalityCountryID= @NationalityCountryID,
                              ImagePath= @ImagePath
                              Where PersonID = @PersonID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);


            if (!string.IsNullOrWhiteSpace(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(Email))
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            if (!string.IsNullOrWhiteSpace(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


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


        public static bool DeletePerson(int PersonID)
        {
            int AffectedRows = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete From People Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

           

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

            return AffectedRows > 0 ;
        }


        public static bool IsPersonExist(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from People Where PersonID = @PersonID";

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

        public static bool IsPersonExist(string NationalNo)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Select Found = 1 from People Where NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName,
                            People.DateOfBirth, People.Gender,
                            CASE
                            WHEN People.Gender = 0 THEN 'Male'
                            WHEN People.Gender = 1 THEN 'Female'
                            ELSE 'UnKnown' END AS GenderCaption,
                            People.Address, People.Phone, People.Email,
                            People.NationalityCountryID, Countries.CountryName, People.ImagePath
                            FROM     People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Order by People.FirstName";

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
