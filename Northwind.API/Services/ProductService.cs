using Northwind.API.DTOs;
using Northwind.API.Models.Context;
using Northwind.API.Repositories;

namespace Northwind.API.Services
{
    public class ProductService : IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductService(NorthwindContext context)
        {
            _context = context;
        }
        public List<ProductDTO> GetAllProducts()
        {
            var products = from p in _context.Products
                           join c in _context.Categories on p.CategoryId equals c.CategoryId
                           join s in _context.Suppliers on p.SupplierId equals s.SupplierId
                           select new ProductDTO
                           {
                               ProductId = p.ProductId,
                               UnitPrice = p.UnitPrice,
                               ProductName = p.ProductName,
                               UnitsInStock = p.UnitsInStock,
                               Category = c,
                               Supplier = s

                           };

            //linq to sql
            //linq to entity
            return products.ToList();

        }
    }
}
