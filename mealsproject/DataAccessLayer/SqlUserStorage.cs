/*namespace MealsProject.DataAccessLayer

{
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using MealsProject.Models;

    internal class SqlUserStorage : //??what repository name?? BaseRepository or IRepository          //all go to BaseRepository

        public static string connectionString = File.ReadAllText(@"C:Users\U1H007\Revature Engineer Bootcamp\Fernando Cabrejo\MealsProject\ConnectionStringMealsProject.txt");

    public User FindUser(string usernameToFind)
    {
       // like in the jsonUserStorage method, create an empty user to hold a potential user we find in the DB
       User foundUser = new User();

       //like INSERT, create a SqlConnection object
       using SqlConnection connection = new SqlConnection(ConnectionString);

       try
       {
         //open the connection
         ConnectionState.Open()
        
       //We start creating our command/Query text
       string cmdText = @"SELECT userId, userPassword, userName 
                          FROM dbo.MealsProject
                          WHERE userName = @userToFind;";
       
       //We create our SqlCommand object
       using SqlCommand cmd - new SqlCommand(cmdText, connection);

       //We then fill in the parameter @userToFind with our string usernameToFind that comes in  as an argument to our method
       cmd.Parameters.AddWithValue("@userToFind", usernameToFind);

       //To execute a query, we need to use a SqlDataReader object.
       //This object reads whatever is returned from our query, row by row - column by column
       //As the reader passes over the columns and rows we need to take steps to store or work with
       //the data that comes back - Once the reader moves on from a row, we wojuld need to execute the 
       //command again to re-read the row.
       //It is forward only! No going back up to another row we have already passed.
        using SqlDataReader reader = cmd.ExecuteReader();

       //We are going to use a while-loop to read through our data coming back from our SqlDataReader
       //and execute code until it is done reading
       while(reader.Read())
       {
        //While we are on a particular row, we have to save stuff if we find it.
        //when using reader.GetType() methods, we have to specify which column we are targeting
        //like arrays, these start at position 0
        foundUser.userId = reader.GetString(0);  //<=*** they are using GetGuid, I'm using just a number
        foundUser.userPassword = reader.GetString(1);
        foundUser.UserName = reader.GetString(2)
       }//once we are done reading, and no more records are coming back to be read, we exit the while-loop

       //we want to close our connection
       connection.Close();
              
       //If we get to this point and ofund a user, we return the filled out user object
       //If the username on foundUser is empty, we manually return a null.
       if (foundUser.userId == String.Empty)  //<=*** they are using Guid instead of String
       {
        return null;
       }

       Otherwise we return ThreadExceptionEventArgs found filled out user            
       return foundUser;

       }




    }

    public void StoreUser(User user)
    {
        using sqlConnection connection = new SqlConnection(connectionString);

        connection,Open();

        string cmdText = @"INSERT INTO dbo.MealsUsers (userId, userPassword, userName)
                            VALUES (@userId, @userPassword, @userName);";

        using SqlCommand cmd= new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@userId, user.userId");
        cmd.Parameters.AddWithValue("@userPassword, user.userPassword");
        cmd.Parameters.AddWithValue("@userName, user.userName");

        cmd.ExecuteNonQuery();

        connection.Close();

    }
}
*/