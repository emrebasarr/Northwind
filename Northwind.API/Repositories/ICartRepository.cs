using Northwind.API.DTOs;

namespace Northwind.API.Repositories
{
    public interface ICartRepository
    {

        void AddItem(CartDTO cartDTO);
        void DeleteItem(int id);

        void UpdateItem(int id, CartDTO cartDTO);
    }
}
