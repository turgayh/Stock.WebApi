using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock.Operation;
using Stock.Operation.CustomerServices;

namespace Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IManagementCustomerService managementCustomerService;

        public CustomerController(IManagementCustomerService managementCustomerService)
        {
            this.managementCustomerService = managementCustomerService;
        }

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer(string customerName)
        {
            Customer data = new Customer();
            data.CustomerName = customerName;
            try
            { 
                managementCustomerService.AddCustomer(data);
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }

            return Ok(data);
        }

        [HttpGet("ListCustomer")]
        public IActionResult ListCustomer()
        {
            List<Customer> data;
            try {
                data = managementCustomerService.ListCustomer();
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }

            return Ok(data);
        }

    }
}