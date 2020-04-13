using System;
using Microsoft.AspNetCore.Mvc;
using Stock.Operation;
using Stock.Operation.BasketServices;
using Stock.Operation.ProductServices;

namespace Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IProductService productService;
        public BasketController(IBasketService basketService, IProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(string productId, string customerName, int quantity)
        {
            if (productId == null)
                return NotFound();

            Product item = productService.Get(productId);
            
            if (item.TotalUnit >= quantity)
            {
                try
                {
                    basketService.AddBasket(item, customerName, quantity);
                }
                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }
            else
                return NotFound("There is no item in stock");

            return Ok(productId);
        }

        [HttpGet("ListBasket")]
        public IActionResult ListBasket(string customerName)
        {
            if (customerName == "")
                return NotFound();

            Basket data = basketService.ListBasket(customerName);
            return Ok(data);
        }
    }
}