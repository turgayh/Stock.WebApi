using System;
using System.Threading.Tasks;
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
        public BasketController(IBasketService basketService,IProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem(Product data,string consumerId,int quantity)
        {
            if (data == null)
                return NotFound();

            Product item =  productService.Get(data.ProductId);
            if(item.TotalUnit != 0)
            {
                try
                {
                    basketService.AddBasket(data,consumerId,quantity);
                }
                catch(Exception err)
                {
                    return BadRequest(err.Message);
                }
            }
            else
                return NotFound("There is no item in stock");

            return Ok(data);
        }

        [HttpGet("ListBasket")]
        public IActionResult ListBasket(string consumerId) {
            if (consumerId == "")
                return NotFound();

            Basket data = basketService.ListBasket(consumerId);
            return Ok(data);
        }
    }
}