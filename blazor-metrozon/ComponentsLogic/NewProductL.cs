using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_metrozon.Models;

namespace blazor_metrozon.ComponentsLogic
{
    public class NewProductL
    {
        public static Product newProduct = new Product(0, 0, 0, 0, 0, 0.0, "", "");
        public static string newProductButtonTitle = "";

        public static void clearProductInfo()
        {
            newProduct.Category_id = 0;
            newProduct.Amount = 0;
            newProduct.Price = 0;
            newProduct.Title = "";
            newProduct.Description = "";
        }
        
        public static async Task saveNewProductData(bool changed)
        {   
            SellerModeL.showDialog = false;
            if (changed)
            {
                await PostgresConnection.ChangeProduct(
                    newProduct.Product_id,
                    newProduct.Category_id,
                    newProduct.Amount,
                    newProduct.Price,
                    newProduct.Title,
                    newProduct.Description);
                BuyerModeL.products = PostgresConnection.ShowProducts();
                SellerModeL.userProducts = SellerModeL.fillUserProducts();
            }
            else
            {
                await PostgresConnection.AddProduct(
                    User.user.User_id,
                    newProduct.Category_id,
                    newProduct.Amount,
                    newProduct.Price,
                    newProduct.Title,
                    newProduct.Description);
                BuyerModeL.products = PostgresConnection.ShowProducts();
                SellerModeL.userProducts.Add(BuyerModeL.products[BuyerModeL.products.Count - 1]);
            }
            clearProductInfo();
        }
    }
}