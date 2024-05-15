namespace MealsProject.DataAccessLayer
{
    using System.Collections.Generic;
    using System.Linq;
    using MealsProject.Utils;

    internal abstract class BaseRepository<T> where T : class
    {
        readonly JsonOperator _jsonOperator;

        protected List<T> _entries = [];

        public BaseRepository(string filename)
        {
            this._jsonOperator = new JsonOperator(filename);
            this.Refresh();
        }

        public void Refresh()
        {
            this._entries = this.GetAll().ToList();
        }

        public IEnumerable<T> GetAll()
        {
            var json = _jsonOperator.ReadFromJson();
            var entries = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>(json);

            return entries;
        }

        public abstract T? Get(int id);

        public bool Add(T entity)
        {
            this._entries.Add(entity);
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