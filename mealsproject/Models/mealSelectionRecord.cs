namespace MealsProject.Models;

    public class MealSelectionRecord
    {
        public Guid userId { get; set; }
        public Guid selectionId { get; set; }
        public Guid priceId { get; set; }
        public string dateChecked { get; set; }
    }
