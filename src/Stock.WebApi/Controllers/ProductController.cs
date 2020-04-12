using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Stock.Operation;
using Stock.Operation.ProductServices;

namespace Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
      
        [HttpGet("ListProduct")]
        public ActionResult<List<Product>> Get() =>
            productService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Product> Get(string id)
        {
            var val = productService.Get(id);

            if (val == null)
            {
                return NotFound();
            }

            return val;
        }

        [HttpPost("CreateProduct")]
        public ActionResult<Product> Create(Product val)
        {
            productService.Create(val);

            return CreatedAtRoute("GetBook", new { id = val.ProductId.ToString() }, val);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product productIn)
        {
            var val = productService.Get(id);

            if (val == null)
            {
                return NotFound();
            }

            productService.Update(id, productIn);

            return NoContent();
        }


    }
}