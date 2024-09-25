using Customer.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet ("{id}")]
        public IActionResult GetCustomerId(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerApi customer)
        {
            _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerId), new { id = customer }, customer);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerApi customer)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
