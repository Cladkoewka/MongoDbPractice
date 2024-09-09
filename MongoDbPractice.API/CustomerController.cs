using Microsoft.AspNetCore.Mvc;
using MongoDbPractice.Domain.Models;
using MongoDbPractice.Logic;

namespace MongoDbPractice.API;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(string id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        return customer != null ? Ok(customer) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer(Customer customer)
    {
        await _customerService.AddCustomerAsync(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCustomer(Customer customer)
    {
        await _customerService.UpdateCustomerAsync(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(string id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}