using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_metrozon.Models;
using blazor_metrozon.Models;

namespace blazor_metrozon.ComponentsLogic
{
    public class Cart
    {
        public static List<Product> products = PostgresConnection.ShowProducts();

        public static string[] statements = { "bag-animate-left", "bag-animate-right" };
        public static string bag_class = "bag-no-animate";
        static int state = 0;
        public static List<Bag> productsInBag = new List<Bag>();

        public static async Task animateBag()
        {
            bag_class = statements[state++ % 2];
            await fillBag();
            productsInBag = await PostgresConnection.GetBagData(User.user.User_id);

        }
        
        public static async Task fillBag()
        {
            productsInBag = await PostgresConnection.GetBagData(User.user.User_id);
        }
    }
}