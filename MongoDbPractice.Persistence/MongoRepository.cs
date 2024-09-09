using MongoDB.Driver;
using MongoDbPractice.Domain.Models;

namespace MongoDbPractice.Persistence;

public class MongoRepository
{
    private readonly IMongoCollection<Customer> _customers;
    
    public MongoRepository(string connectionString)
    {
        var mongoUrl = MongoUrl.Create(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        _customers = database.GetCollection<Customer>("customer");
    }

    
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _customers.Find(FilterDefinition<Customer>.Empty).ToListAsync();
    }
    
    public async Task<Customer?> GetCustomerByIdAsync(string id)
    {
        var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
        return await _customers.Find(filter).FirstOrDefaultAsync();
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _customers.InsertOneAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
        var update = Builders<Customer>.Update
            .Set(x => x.CustomerName, customer.CustomerName)
            .Set(x => x.Email, customer.Email);
        await _customers.UpdateOneAsync(filter, update);

        //await _customers.ReplaceOneAsync(filter, customer);
    }
    
    public async Task DeleteCustomerAsync(string id)
    {
        var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
        await _customers.DeleteOneAsync(filter);
    }
}