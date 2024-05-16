namespace MealsProject.DataAccessLayer
{
    using System.Linq;
    using MealsProject.Models;

    internal class UserRepository : BaseRepository<User>
    {
        int _currentId;

        public UserRepository(): base ($"Resources/User.json")
        {
            this._currentId = this._entries.Max(x => x.Id);
        }

        public new User Add(User user)
        {
            user.Id = ++this._currentId;
            base.Add(user);
            return user;
        }

        //public void Update(User user)
        //{
        //    Delete(user);
        //    Add(user);
        //}

        public new bool Delete (User user)
        {
            var deleteUser = this._entries.SingleOrDefault(x=>x.UserName == user.UserName);
            if (deleteUser != null)
            {
                base.Delete(deleteUser);
            }

            return true;
        }

        public override User? Get(int id)
        {
            var user = this._entries.FirstOrDefault(user => user.Id == id);
            return user;
        }
    }
}