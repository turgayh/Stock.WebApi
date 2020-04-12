using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock.Model;
using Stock.Operation.BasketServices;
using Stock.Operation.ProductServices;

namespace Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IProductService productService;
        public BasketController(IBasketService basketService,IProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }

        [HttpPost("AddItem")]
        public ActionResult<String> AddItem(OrderItem data)
        {
            Product item =  productService.Get(data.ProductId);
            if(item.TotalUnit != 0)
            {
                try
                {
                    basketService.AddBasket(data);
                }
                catch(Exception err)
                {
                    return err.Source;
                }
            }
            else =>
                return "Sold Out";

            return "Added Successfully";
        }
    }
}