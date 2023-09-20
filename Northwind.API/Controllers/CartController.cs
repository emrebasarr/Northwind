using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.API.DTOs;
using Northwind.API.Helpers;
using Northwind.API.Repositories;
using Northwind.API.Services;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public CartController(IProductRepository productRepository,ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }


        //MyCart'ı temsil edern endpoint oluşturun.
        [HttpGet]
        [Route("getitems")]
        public IActionResult GetItems()
        {
            var cartSession = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
            if (cartSession == null)
            {
                return NotFound("sepeteniz boş!");
            }
            else
            {
                return Ok(cartSession.MyCart.Values.ToList());
            }
        }


        //Delete İşlemi
        [HttpDelete]
        [Route("deleteitems/{id}")]
        public IActionResult DeleteItems(int id)
        {
            var product = _productRepository.GetAllProducts().FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound("Ürün Silinemedi");
            }
            else
            {
                _cartRepository.DeleteItem(id);
                return Ok("Sepetteki Ürün Silindi");
            }
        }

        //Update işlemi
        [HttpPut]
        [Route("updateitems/{id}")]
        public IActionResult UpdateItems(int id , short quantity)
        {
            var cart = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
            cart.UpdateItem(id, quantity);
            SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cart);
            return Ok("Sepet Güncellendi");
        }

        [HttpGet]
        [Route("addtocart/{id}")]
        public IActionResult AddToCart(int id)
        {

            //CartService cartService = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet") == null ? new CartService() : SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");

            CartService cartService;

            if (SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet") == null)
            {
                cartService = new CartService();
            }
            else
            {
                cartService = SessionHelper.GetProductFromJson<CartService>(HttpContext.Session, "sepet");
            }

            var product = _productRepository.GetAllProducts().FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound("ürün bulunamadı!");
            }
            else
            {

                //araştırma: AutoMapper nedir? ne için kullanılır araştırın.

                //araştırma: AutoFac nedir? ne için kullanılır?

                CartDTO cartDTO = new CartDTO
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice
                };
                cartService.AddItem(cartDTO);
                SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartService);

                return Ok(cartDTO);
            }
        }
    }
}
