using MongoDB.Driver;
using MongoDbPractice.Domain.Models;
using MongoDbPractice.Persistence;

namespace MongoDbPractice.Logic;

public class CustomerService
{
    private readonly MongoRepository _mongoRepository;

    public CustomerService(MongoRepository mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _mongoRepository.GetAllCustomersAsync();
    }
    
    public async Task<Customer?> GetCustomerByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            throw new ArgumentException("ID cannot be null or empty.", nameof(id));
        
        return await _mongoRepository.GetCustomerByIdAsync(id);
    }
    
    public async Task AddCustomerAsync(Customer customer)
    {
        if (customer == null) 
            throw new ArgumentNullException(nameof(customer));
        
         await _mongoRepository.AddCustomerAsync(customer);
    }
    
    public async Task UpdateCustomerAsync(Customer customer)
    {
        if (customer == null) 
            throw new ArgumentNullException(nameof(customer));
        
        var existingCustomer = await _mongoRepository.GetCustomerByIdAsync(customer.Id);
        if (existingCustomer == null) 
            throw new KeyNotFoundException("Customer not found.");
        
        await _mongoRepository.UpdateCustomerAsync(customer);
    }
    
    public async Task DeleteCustomerAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            throw new ArgumentException("ID cannot be null or empty.", nameof(id));
        
        var existingCustomer = await _mongoRepository.GetCustomerByIdAsync(id);
        if (existingCustomer == null) 
            throw new KeyNotFoundException("Customer not found.");
        
        await _mongoRepository.DeleteCustomerAsync(id);
    }
}