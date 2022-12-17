using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_metrozon.Components;
using blazor_metrozon.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;


namespace blazor_metrozon.ComponentsLogic
{
    public class NavbarL
    {
        public static string grad_class = "grad";
        public static string placeholder = "Введите название товара";

        public static List<Category> categories = new List<Category>(PostgresConnection.GetCategories());

        public static void changeMod()
        {
            if (BuyerModeL.buyermod)
            {
                BuyerModeL.buyermod = false;
                grad_class = "grad-sell-mod";
                placeholder = "Поиск по вашим товарам";
            }
            else
            {
                BuyerModeL.buyermod = true;
                CartL.bag_class = "bag-no-animate";
                grad_class = "grad";
                placeholder = "Введите название товара";
            }
        }
    }
    
    
}