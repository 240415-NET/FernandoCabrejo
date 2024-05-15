namespace MealsProject.DataAccessLayer
{
    using System.Linq;
    using MealsProject.Models;

    internal class MenuRepository : BaseRepository<Menu>
    {
        int _currentId;

        public MenuRepository() : base("Resources/Menu.json")
        {
            this._currentId = this._entries.Max(x => x.Id);
        }

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