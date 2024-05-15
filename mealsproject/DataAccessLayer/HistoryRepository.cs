namespace MealsProject.DataAccessLayer
{
    using System.Linq;
    using MealsProject.Models;

    internal class HistoryRepository: BaseRepository<History>
    {
        int _currentId;

        public HistoryRepository() : base("Resources/History.json")
        {
            this._currentId = this._entries.Max(x => x.Id);
        }

        public new History Add(History history)
        {
            history.Id = ++this._currentId;
            base.Add(history);
            return history;
        }

        public override History? Get(int id)
        {
            var history = this._entries.FirstOrDefault(history => history.Id == id);
            return history;
        }
    }
}