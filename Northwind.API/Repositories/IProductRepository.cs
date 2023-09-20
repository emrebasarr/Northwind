using Northwind.API.DTOs;

namespace Northwind.API.Repositories
{
    public interface IProductRepository
    {
        List<ProductDTO> GetAllProducts();
    }
}
