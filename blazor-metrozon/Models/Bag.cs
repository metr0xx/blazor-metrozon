namespace blazor_metrozon.Models
{
    public class Bag
    {
        public int User_id { get; set; }
        public int In_bag { get; set; }
        public int Amount { get; set; }

        public Bag(int userId, int in_bag, int amount)
        {
            User_id = userId;
            In_bag = in_bag;
            Amount = amount;
        }
    }
}