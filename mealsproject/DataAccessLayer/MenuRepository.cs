namespace MealsProject.DataAccessLayer
{
    using System.Data.SqlClient;
    using System.Linq;
    using MealsProject.Models;
    

    public class MenuRepository                                                                                       // taking out ': BaseRepository<User>'          
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";

        public static string connectionString = File.ReadAllText(connectionPath);
        public List<MenuItems> RetrieveChoicesList(Int32 itemIdToFind)
        {
            List<MenuItems> ChoicesListFromStorage = new List<MenuItems>();
            using SqlConnection myConnectionObject = new SqlConnection(connectionString);
            myConnectionObject.Open();

            string commandTextForRetrievingChoicesList = @"SELECT * FROM MealsMenu;";               //Display all items when called from 1. View Menu

            using SqlCommand commandForRetrievingChoicesList = new SqlCommand(commandTextForRetrievingChoicesList, myConnectionObject);
            commandForRetrievingChoicesList.Parameters.AddWithValue("@ItemId", itemIdToFind);

            using SqlDataReader reader = commandForRetrievingChoicesList.ExecuteReader();

            while (reader.Read())
            {
                int ItemId = reader.GetInt32(0);
                string ItemName = reader.GetString(1);
                double Price = (double)reader.GetDecimal(2);
            }

            myConnectionObject.Close();

            return ChoicesListFromStorage;

        } 
    }
}



/* code removed to use SQL
         internal class MenuRepository : BaseRepository<Menu>       //all go to BaseRepository
    {
        int _currentId;
       // public MenuRepository() : base("Resources/Menu.json")
       // {
        //    this._currentId = this._entries.Max(x => x.Id);
        //}

        public new Menu Add(Menu menu)
        {
            menu.Id = ++this._currentId;
            base.Add(menu);
            return menu;
        }

        public override Menu?   Get(int id)
        {
            var menu = this._entries.FirstOrDefault(menu => menu.Id == id);
            return menu;
        }
    }
}
*/