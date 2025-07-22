namespace FoodCollection.Models
{
    public class FoodItemVM
    {
        public int FoodItemId { get; set; }
        public int countofFoodItems { get; set; }
    }

    public class DashboardVM
    {
        public List<Payment> payments { get; set; }
        public List<FoodItemVM> fooditems { get; set; }
    }
}
