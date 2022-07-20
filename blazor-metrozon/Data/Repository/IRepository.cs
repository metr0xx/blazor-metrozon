using blazor_metrozon.Models;
using System.Collections.Generic;

namespace blazor_metrozon.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(int Salesman_id, int Group_id, int Remains, int Value, string Name);
        void ChangeValue(Product changedProduct);
        void DeleteProduct(int Product_id);
    }  
}
