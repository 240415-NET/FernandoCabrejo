using System.ComponentModel;

namespace MealsProject.Models
{

    public class History
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public List<int> ItemNumbers { get; set; }

        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}