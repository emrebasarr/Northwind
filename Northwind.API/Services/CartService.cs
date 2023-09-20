using Northwind.API.DTOs;
using Northwind.API.Repositories;

namespace Northwind.API.Services
{
    public class CartService : ICartRepository
    {
        public Dictionary<int, CartDTO> MyCart = new Dictionary<int, CartDTO>();
        public void AddItem(CartDTO cartDTO)
        {
            if (MyCart.ContainsKey(cartDTO.Id))
            {
                MyCart[cartDTO.Id].Quantity += 1;
                return;
            }
            MyCart.Add(cartDTO.Id, cartDTO);
        }

        //Delete item
        public void DeleteItem(int id)
        {
            if (MyCart.ContainsKey(id))
            {
                MyCart.Remove(id);
            }
        }


        //Update item
        public void UpdateItem(int id, short quantity)
        {
            if (MyCart.ContainsKey(id))
            {
                MyCart[id].Quantity = quantity;
            }
        }
    }
}