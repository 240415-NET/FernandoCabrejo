namespace MealsProject.DataAccessLayer
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection.Metadata;
    using MealsProject.Models;

    public class UserRepository                                                                                         
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";

        public static string connectionString = File.ReadAllText(connectionPath);
        public SqlCommand sqlCommand;

        int _currentId;

        public static Response ValidateUserByNameAndPassword(string username, string password)
        {
            var response = new Response();
            try
            {
                var users = RetrieveStoredUser(username);
                if (users == null)
                {
                    throw new InvalidDataException("Invalid User Name or Password");
                }
                if (password == users.Password)
                {
                    response.ObjectResponse = users;
                    response.Message = $"User {users.UserName} Logged In!";
                    response.Success = true;
                }
                else
                {
                    response.ObjectResponse = users;
                    response.Message = $"Invalid User Name or Password";
                    response.Success = false;
                }
            }
            catch (Exception e)
            {
                     response.Success = false;
           response.Message = e.Message;
            }
            return response;
        }

                public static User RetrieveStoredUser(string userNameToFind)
                {
                    User existingUser = new User();
                    try
                    {
                        using SqlConnection myConnectionObject = new SqlConnection(connectionString);                                        
                        myConnectionObject.Open();

                        string SQLCodeToRetrieveUser = @"SELECT userId, userPassword, userName FROM MealsUsers WHERE userName = @userName";  //use this connection and run this query

                        using SqlCommand RetrieveUserCommand = new SqlCommand(SQLCodeToRetrieveUser, myConnectionObject);                    

                        RetrieveUserCommand.Parameters.AddWithValue("@userName", userNameToFind);

                        using SqlDataReader mealsReader = RetrieveUserCommand.ExecuteReader();

                        while (mealsReader.Read())
                        {
                            existingUser.Id = int.Parse(mealsReader.GetString(0));
                            string Password = mealsReader.GetString(1);
                            string userName = mealsReader.GetString(2);
                            existingUser.UserName = userName;
                            existingUser.Password = Password;
                        }
                        myConnectionObject.Close();
                    }
                    catch (Exception e)
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