using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_metrozon.Models;

namespace blazor_metrozon.ComponentsLogic
{
    public class SellerModeL
    {
        public static bool showDialog;
        public static List<Product> userProducts = new List<Product>(fillUserProducts());
        
        public static List<Product> fillUserProducts()
        {
            var userProducts = new List<Product>();
            foreach (var product in BuyerModeL.products)
            {
                if (product.Seller_id == User.user.User_id)
                {
                    userProducts.Add(product);
                }
            }
            return userProducts;
        }
        
        public static void toggleShowDialog(bool changed, int product_id = 0)
        {
            NewProductL.newProduct.Product_id = product_id;
            NewProductL.newProductButtonTitle = changed ? "Изменить" : "Добавить";
            showDialog = !showDialog;
            NewProductL.clearProductInfo();
        }
        
        public static async Task deleteProduct(int product_id)
        {
            // warning dialog
            await PostgresConnection.DeleteProduct(product_id);
            BuyerModeL.products = PostgresConnection.ShowProducts();
            userProducts = fillUserProducts();
        }
    }
    
    
}