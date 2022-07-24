using blazor_metrozon.Models;
using System.Collections.Generic;

namespace blazor_metrozon.Data.Repository
{
    public class SQLRepos : IRepository
    {
        private readonly DB _context;
        public SQLRepos(DB context)
        {
            _context = context;
        }

        public void AddProduct(int Selesman_id, int group_id, int remains, int value, string Name)
        {
            Product newProduct = new Product()
            {
                Seller_id = Selesman_id,
                Category_id = group_id,
                Amount = remains,
                Price = value,
                Title = Name,
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void ChangeValue(Product changedProduct)
        {
            var product = _context.Products.Attach(changedProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }

        public void DeleteProduct(int Product_id)
        {
            var deletedProduct = _context.Products.Find(Product_id);

            if(deletedProduct != null)
            {
                _context.Products.Remove(deletedProduct);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
