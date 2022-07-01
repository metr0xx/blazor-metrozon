namespace blazor_metrozon.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public int seller_id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public double rating { get; set; }
        public string name { get; set; }
        public string category_id { get; set; }
    }
}
