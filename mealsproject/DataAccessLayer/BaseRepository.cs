namespace MealsProject.DataAccessLayer
{
    using System.Collections.Generic;
    using System.Linq;
    using MealsProject.Utils;
    using System.Data.Common;
    using System.Reflection.Metadata;

    internal abstract class BaseRepository<T> where T : class

   {
        private static string connectionString = File.ReadAllText(@"C:Users\U1H007\Revature Engineer Bootcamp\Fernando Cabrejo\MealsProject\ConnectionStringMealsProject.txt");

       //  SqlConnection connection;
       //  SqlCommand command;

        readonly JsonOperator _jsonOperator;

        protected List<T> _entries = [];

         public BaseRepository(string filename)    //Constructor for filename
         {
             this._jsonOperator = new JsonOperator(filename);
             this.Refresh();
         }

        public void Refresh()
        {
            this._entries = this.GetAll().ToList();
        }

        public IEnumerable<T> GetAll()                                      //(string query)Base interface for all non-generic collections
        
        { /*
            connection = new SqlConnection(connectionString);
            using(connection)
            {
                connection.Open();
                 command = new SqlCommand(query, connection);
                 using SqlDataReader reader = command.ExecuteReader();
            }
           */
            var json = _jsonOperator.ReadFromJson();     //The operator is to read from json
            var entries = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>(json);

            return entries;
        }
        

        public abstract T? Get(int id);

        public bool Add(T entity)
        {
            this._entries.Add(entity);                 //The operator is to add to json
            this._jsonOperator.WriteToJson(this._entries);
            this.Refresh();
            return true;
        }

        public bool Delete(T entity)
        {
            this._entries.Remove(entity);
            this._jsonOperator.WriteToJson(this._entries);
            this.Refresh();
            return true;
        }
    }
}