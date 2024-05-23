namespace MealsProject.Models
{
    public class Menu
    {
        public int Id {get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }
    }
}

/*
namespace MealsProject.Models;

    public class MealSelectionRecord             //from video: public class Item
    {
        public Guid userId { get; set; }         // int userId {get; set;}
        public Guid selectionId { get; set; }    // int itemId {get; set;}
        public Guid priceId { get; set; }        // price double originalCost {get; set;}
        public string dateChecked { get; set; }  // public DateTime purchaseDate {get; set;}
                                                 // public string description {get; set;}
                                                 // *also added from pet a no argument constructor*
                                                 // public Item() {}
    }
*/