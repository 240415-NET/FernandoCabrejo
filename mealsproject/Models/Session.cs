namespace MealsProject.Models
{
    using System.Collections.Generic;

    internal class Session
    {
        public Session(User user)
        {
            this.User = user;
            this.OrderList = new List<Menu>();
        }

        public User? User { get; }

        public List<Menu> OrderList { get; set; }
    }
}