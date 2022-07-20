namespace blazor_metrozon.Models
{
    public class Product
    {
        public int Product_id { get; set; }
        public int Seller_id { get; set; }
        public int Category_id { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public double Rating { get; set; }
        public string Title { get; set; }
    }
}
