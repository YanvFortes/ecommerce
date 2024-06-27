using System.Collections.Generic;
using System.Linq;
using EcommerceStudy.Data;
using EcommerceStudy.Models.Products;

namespace EcommerceStudy.Models
{
    public class Admin
    {
        private readonly AppDbContext _context;

        public Admin(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }


        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void RemoveProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }
    }
}
