namespace MealsProject.DataAccessLayer
{
    using System.Linq;
    using MealsProject.Models;
    using System.Data.SqlClient;


     internal class HistoryRepository                                              //all go to BaseRepository
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";
        string connectionString = File.ReadAllText(connectionPath);

        //public HistoryRepository() : base("Resources/History.json")
        //{
        //    this._currentId = this._entries.Max(x => x.Id);
        //}

        public new History Add(History history)
        {
           // history.Id = ++this._currentId;
            StoreMealsOrderHistory(history);                                              //base.Add(history);
            return history;
        }

        //public History? Get(int id)
        //{
        //    var history = this._entries.FirstOrDefault(history => history.Id == id);
        //    return history;
        //}

public void StoreMealsOrderHistory(History userMealHistory)
        {
            using SqlConnection myConnectionObject = new SqlConnection(connectionString);
            myConnectionObject.Open();
                                                                                   //HistoryId is incremented with new date userid itemid
                                                                                   //have to check that history id increments on every order. Rows inserted when placing an order
            foreach (var itemId in userMealHistory.ItemNumbers)
            {
            string SQLCodeToAddUserMealHistory =                                       
             @"INSERT INTO MealsHistory
               VALUES (@Date, @UserId, @ItemId);";                 

            using SqlCommand AddUserMealHistoryCommand = new SqlCommand(SQLCodeToAddUserMealHistory, myConnectionObject);

            AddUserMealHistoryCommand.Parameters.AddWithValue("@Date", userMealHistory.Date);
            AddUserMealHistoryCommand.Parameters.AddWithValue("@UserId", userMealHistory.UserId);
            AddUserMealHistoryCommand.Parameters.AddWithValue("@ItemId", itemId);
            AddUserMealHistoryCommand.ExecuteNonQuery();

            }
            myConnectionObject.Close();
        }





    }
}



        

/*
public class SQLMealsOrderHistory
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";
        string connectionString = File.ReadAllText(connectionPath);

        public void StoreMealsOrderHistory(int HistoryId, MealsHistory userMealHistory)
        {
            mySQLConnection.Open();
                                                                                   //HistoryId is incremented with new date userid itemid
                                                                                   //have to check that history id increments on every order. Rows inserted when placing an order
            string SQLCodeToAddUserMealHistory =                                       
             @"INSERT INTO MealsHistory (HistoryId, Date, UserId, ItemId)              
               VALUES (@HistoryId, @Date, @UserId, @ItemId);";                 

            using SqlCommand AddUserMealHistoryCommand = new SqlCommand(SQLCodeToAddUserMealHistory, mySQLConnection);

            AddUserMealHistoryCommand.Parameters.AddWithValue("@HistoryId", HistoryId);
            AddUserMealHistoryCommand.Parameters.AddWithValue("@Date", userMealHistory.Date);
            AddUserMealHistoryCommand.Parameters.AddWithValue("@UserId", userMealHistory.UserId);
            AddUserMealHistoryCommand.Parameters.AddWithValue("@ItemId", userMealHistory.ItemId);
            AddUserMealHistoryCommand.ExecuteNonQuery();

            mySQLConnection.Close();
        }
        
    }

    SELECT MealsMenu.itemName, MealsMenu.Price, MealsHistory.Date
FROM MealsHistory
	INNER JOIN MealsMenu ON MealsHistory.ItemId = MealsMenu.itemId
WHERE MealsHistory.itemid (@ITEMIDSELECTED FROM SESSION)
;
*/