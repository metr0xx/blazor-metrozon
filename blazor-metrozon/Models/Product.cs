namespace blazor_metrozon.Models
{
    public class Product
    {
        public int Product_id { get; set; }
        public int Seller_id { get; set; }
        public int Category_id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Product(int product_id, int seller_id, int category_id, int amount, int price, double rating, string title, string description)
        {
            Product_id = product_id;
            Seller_id = seller_id;
            Category_id = category_id;
            Amount = amount;
            Price = price;
            Rating = rating;
            Title = title;
            Description = description;
        }
    }
    
}
