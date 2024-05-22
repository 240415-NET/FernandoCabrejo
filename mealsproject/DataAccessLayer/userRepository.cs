namespace MealsProject.DataAccessLayer
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection.Metadata;
    using MealsProject.Models;

    public class UserRepository                                                                                  // taking out ': BaseRepository<User>'          
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";

        public static string connectionString = File.ReadAllText(connectionPath);
        public SqlCommand sqlCommand;

        int _currentId;

        public User RetrieveStoredUser(string userNameToFind)
        {
            User existingUser = new User("User name not found");
            try
            {
                using SqlConnection myConnectionObject = new SqlConnection(connectionString);                                        //had (this.  before
                myConnectionObject.Open();                                                                                 
                
                string SQLCodeToRetrieveUser = @"SELECT userId, userPassword, userName FROM MealsUsers WHERE userName = @userName";  //create parametized string

                using SqlCommand RetrieveUserCommand = new SqlCommand(SQLCodeToRetrieveUser, myConnectionObject);                             //Query results, use this connection and run this query

                RetrieveUserCommand.Parameters.AddWithValue("@userName", userNameToFind);                                

                using SqlDataReader mealsReader = RetrieveUserCommand.ExecuteReader();

                while (mealsReader.Read())
                {
                    existingUser.Id = mealsReader.GetInt32(0);
                    string Password = mealsReader.GetString(1);
                    string userName = mealsReader.GetString(2);
                    existingUser.UserName = userName;
                }
                myConnectionObject.Close();                                                                          
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            if (existingUser.UserName == "User name not found")
            {
                return null;
            }
            else
            {
                return existingUser;
            }
        }
    }
}

 /*
    public User Get(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);                         //Using makes it a disposable connection once we are done with it
                                                                                                          //created SqlConnection object, constructor needs the connectionString
            connection.Open();                                                                            //Logical openning a connection with connection.Open

            User user = new();

            string command = @"SELECT userId, userPassword, userName from MealsUsers where userId = @id";  //create parametized string

            using SqlCommand mealsUsers = new SqlCommand(command, connection);                             //Query results, use this connection and run this query

            mealsUsers.Parameters.AddWithValue("@id", Convert.ToString(id));                                //

            using SqlDataReader mealsReader = mealsUsers.ExecuteReader();

            while (mealsReader.Read())
            {
                user.Id = mealsReader.GetInt32(0);
                user.Password = mealsReader.GetString(1);
                user.UserName = mealsReader.GetString(2);
            }
            connection.Close();                                                                             //Manually closing connection and dispose of entire object
            return user;                                                                                    //return user object
        }



//old GetAll method
        /*                                                                                                     Verify the usability of the removed code
         public List<User> GetAll()
         {
             SqlConnection = new SqlConnection(connectionString);

             User user = new User();

             List<User> users = new List<User>();

             string command = $"Select * from mealsuser";

             using (SqlConnection)
             {
                 sqlCommand.CommandType = System.Data.CommandType.Text;
                 SqlConnection.Open();
                 sqlCommand = new SqlCommand(command, sqlConnection);
                 SqlDataReader reader = sqlCommand.ExecuteReader();

                 while (reader.Read())
                 {
                     user.Id = reader.GetInt32(0);
                     user.UserName = reader.GetString(1);
                     user.Password = reader.GetString(2);

                     users.Add(user);
                 }
             }

             return users;
         }
         */
