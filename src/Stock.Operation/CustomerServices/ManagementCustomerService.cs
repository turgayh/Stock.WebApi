using System.Collections.Generic;
using MongoDB.Driver;
using Stock.Operation.DatabaseHelper;

namespace Stock.Operation.CustomerServices
{
    public class ManagementCustomerService:IManagementCustomerService
    {

        private readonly IMongoCollection<Customer> customer;

        public ManagementCustomerService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public Customer AddCustomer(Customer data)
        {
            customer.InsertOne(data);
            return data;
        }

        public List<Customer> ListCustomer()
        {
            return customer.Find(val => true).ToList();
        }
    }
}
