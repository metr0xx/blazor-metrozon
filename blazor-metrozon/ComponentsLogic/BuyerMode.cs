using System.Collections.Generic;
using blazor_metrozon.Models;

namespace blazor_metrozon.ComponentsLogic
{
    public partial class BuyerModeL
    {
        
         public static bool buyermod = true;
         public static List<Product> products = PostgresConnection.ShowProducts();

    }
}