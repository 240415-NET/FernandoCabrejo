using System.ComponentModel;

namespace MealsProject.Models
{

    public class History
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public int UserId { get; set; }

        public List<int> ItemNumbers { get; set; }

        public int itemNum { get; set; }     //in case want to use a single num in the future instead of a list of one

        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}