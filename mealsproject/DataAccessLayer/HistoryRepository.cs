namespace MealsProject.DataAccessLayer
{
    using System.Linq;
    using MealsProject.Models;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System;
    using System.Net.Mail;
    using System.Data.Common;

    public class HistoryRepository                                                        //changed from internal to public
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";
        public static string connectionString = File.ReadAllText(connectionPath);

        public new List<History> Add(History history)
        {
            StoreMealsOrderHistory(history);                        
            return RetrieveHistoryList(history.UserId);
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

        public static List<History> RetrieveHistoryList(int userId)
        
        {
            List<History> HistoryListFromStorage = new List<History>();
            using SqlConnection myConnectionObject = new SqlConnection(connectionString);
            myConnectionObject.Open();

            string commandTextForRetrievingHistoryList = 
            @"SELECT h.historyid, h.itemId, m.itemName, m.Price, h.Date
             FROM MealsHistory h Inner join MealsMenu m on h.itemid = m.itemid 
             WHERE h.userId = @userId;";                                                   //Displays all items on history when called from 3. View History

            using SqlCommand commandForRetrievingHistoryList = new SqlCommand(commandTextForRetrievingHistoryList, myConnectionObject);
            
            commandForRetrievingHistoryList.Parameters.AddWithValue("@userId", userId);

            using SqlDataReader reader = commandForRetrievingHistoryList.ExecuteReader();
            
            while (reader.Read())
            {
                var history = new History();
                history.Id = reader.GetInt32(0);
                history.Date = reader.GetDateTime(4);
                history.ItemName = reader.GetString(2);
                history.Price = reader.GetDecimal(3);
                
                HistoryListFromStorage.Add(history);
            }

            myConnectionObject.Close();

            return HistoryListFromStorage;
        }
    }

    public class history
    {
    }
}