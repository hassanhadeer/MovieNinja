using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MovieNinja.Models
{
    public class DataNinja
    {
        public string movieID = "";
        public string poster_path = "";
        public string overview = "";
        
        public void Login(string username, string password) 
        {
            using(SqlConnection myConn = new SqlConnection(Program.fetch.cs))
            {
                SqlCommand login = new SqlCommand();
                login.Connection = myConn;
                myConn.Open();

                login.Parameters.AddWithValue("@username", username);
                login.Parameters.AddWithValue("@password", password);

                login.CommandText = ("[spLogin]");
                login.CommandType = System.Data.CommandType.StoredProcedure;

                var userID = login.ExecuteScalar();

                if(Convert.ToInt32(userID) != 0 || userID != null) {
                    Program.userID = Convert.ToInt32(userID);
                }
            } // using
        } // Login()
        public void Logout() 
        {
            Program.userID = 0;
        } // Logout()
        public void Signup(string username, string password, string email) {

            using(SqlConnection myConn = new SqlConnection(Program.fetch.cs))
            {
                // username check - does it exist!
                // first we should check to see if the username
                SqlCommand userCheck = new SqlCommand();
                userCheck.Connection = myConn;
                myConn.Open();

                userCheck.Parameters.AddWithValue("@username", username);

                userCheck.CommandText = ("[spUserDuplicateCheck]");
                userCheck.CommandType = System.Data.CommandType.StoredProcedure;

                var userResult = userCheck.ExecuteScalar();

                if(Convert.ToInt32(userResult) == 1) {
                    // username is used!
                    // exit and alert the user
                }
                else {
                    SqlCommand createUser = new SqlCommand();
                    createUser.Connection = myConn;

                    string hashedPassword = HashPassword(password);

                    createUser.Parameters.AddWithValue("@username", username);
                    createUser.Parameters.AddWithValue("@password", hashedPassword);
                    createUser.Parameters.AddWithValue("@email", email);

                    createUser.CommandText = ("[spAddUser]");
                    createUser.CommandType = System.Data.CommandType.StoredProcedure;

                    // createUser.ExecuteNonQuery();

                    var result = createUser.ExecuteScalar();

                    if(result != null)
                    {
                        Program.userID = Convert.ToInt32(result);
                    }
                } // else
            } // using
        } // OnPostSignup()
        public string HashPassword(string pass) {
            string newPass = "";
            
            var sha1 = new SHA1CryptoServiceProvider(); 
            var data = Encoding.ASCII.GetBytes(pass);
            var sha1data = sha1.ComputeHash(data);
            // newPass = ASCIIEncoding.GetString(sha1data);

            return newPass;
        } // HashPassword()
        public void AddToWatch(string movieID, string poster_path, string overview, string userID) {
            using(SqlConnection myConn = new SqlConnection(Program.fetch.cs))
            {
                SqlCommand addWatch = new SqlCommand();
                addWatch.Connection = myConn;
                myConn.Open();

                addWatch.Parameters.AddWithValue("@movieID", Convert.ToInt32(movieID)); // int
                addWatch.Parameters.AddWithValue("@poster_path", poster_path);
                addWatch.Parameters.AddWithValue("@overview", overview);
                addWatch.Parameters.AddWithValue("@userID", Convert.ToInt32(userID)); // int

                addWatch.CommandText = ("[spAddWatch]");
                addWatch.CommandType = System.Data.CommandType.StoredProcedure;

                addWatch.ExecuteNonQuery();
            }
        }
    } // class
} // namespace