namespace MealsProject.DataAccessLayer
{
    using System.Linq;
    using MealsProject.Models;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System;
    using System.Net.Mail;
    using System.Data.Common;

    public class HistoryRepository                                              //change from internal to public, previously all go to BaseRepository
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";
        public static string connectionString = File.ReadAllText(connectionPath);

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

        public void StoreMealsOrderHistory(History userMealHistory)
        {
            using SqlConnection myConnectionObject = new SqlConnection(connectionString);
            myConnectionObject.Open();
    
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

        // Retrieving the orders placed from SQL
        //public History? Get(int id)                                                                   //reopening to get the order history
        //{
        //     var history = RetrieveHistoryList().FirstOrDefault(x=>x.Id.Equals(id));                   //this._entries.FirstOrDefault(history => history.Id == id);
        //    return history;
        //}

        //public new History Add(History history)
        //{
           // history.Id = ++this._currentId;
        //    StoreMealsOrderHistory(history);                                              //base.Add(history);
        //    return history;
        //}
        //var histories = (List<History>)historyResponse.ObjectResponse;                    //from program,cs line 164
        public static List<History> RetrieveHistoryList(int userId)
        
        {
            List<History> HistoryListFromStorage = new List<History>();
            using SqlConnection myConnectionObject = new SqlConnection(connectionString);
            myConnectionObject.Open();

            string commandTextForRetrievingHistoryList = 
            @"SELECT h.historyid, h.itemId, m.itemName, m.Price, h.Date
             FROM MealsHistory h Inner join MealsMenu m on h.itemid = m.itemid 
             WHERE h.userId = @userId;";    //Display all items on history when called from 3. View History

            using SqlCommand commandForRetrievingHistoryList = new SqlCommand(commandTextForRetrievingHistoryList, myConnectionObject);
            
            commandForRetrievingHistoryList.Parameters.AddWithValue("@userId", userId);

            using SqlDataReader reader = commandForRetrievingHistoryList.ExecuteReader();
            
            while (reader.Read())
            {
                var history = new History();
                history.Id = reader.GetInt32(0);
               // history.itemId = reader.GetInt32(1);
                DateTime Date = reader.GetDateTime(4);
                history.Date = Date.ToString("yyyyMMdd");
                history.ItemName = reader.GetString(2);
                history.Price = reader.GetDecimal(3);
                
                HistoryListFromStorage.Add(history);
            }

            myConnectionObject.Close();

            return HistoryListFromStorage;
        }

        //public IEnumerable<object> GetAll()                                                     //changing internal to public
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class history
    {
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