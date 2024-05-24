namespace MealsProject.DataAccessLayer
{
    using System.Data.SqlClient;
    using System.Linq;
    using MealsProject.Models;
    

    
    public class MenuRepository                                                                                        //change from internal to public
    {
        public static string connectionPath = @"C:\Users\U1H007\Revature Engineer Bootcamp\FernandoCabrejo\mealsproject\ConnectionStringMealsProject.txt";

        public static string connectionString = File.ReadAllText(connectionPath);
        public Menu? Get(int id)
        {
            var menu = RetrieveChoicesList().FirstOrDefault(x=>x.Id.Equals(id));
            return menu;
        }

        public List<Menu> GetAll()
        {
            return RetrieveChoicesList();
        }

        public List<Menu> RetrieveChoicesList()
        {
            List<Menu> ChoicesListFromStorage = new List<Menu>();
            using SqlConnection myConnectionObject = new SqlConnection(connectionString);
            myConnectionObject.Open();

            string commandTextForRetrievingChoicesList = @"SELECT * FROM MealsMenu;";               //Displays all items when called from 1. View Menu

            using SqlCommand commandForRetrievingChoicesList = new SqlCommand(commandTextForRetrievingChoicesList, myConnectionObject);
            
            using SqlDataReader reader = commandForRetrievingChoicesList.ExecuteReader();
            while (reader.Read())
            {
                var menu = new Menu();
                menu.Id = reader.GetInt32(0);
                menu.ItemName = reader.GetString(1);
                menu.Price = reader.GetDecimal(2);
                
                ChoicesListFromStorage.Add(menu);
            }

            myConnectionObject.Close();

            return ChoicesListFromStorage;

        } 
    }
}