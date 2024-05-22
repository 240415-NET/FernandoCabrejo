namespace MealsProject.Models
{

    public class History
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public int UserId { get; set; }

        public List<int> ItemNumbers { get; set; }
    }
}