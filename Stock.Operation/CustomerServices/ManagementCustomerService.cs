using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Stock.Model;

namespace Stock.Operation.CustomerServices
{
    public class ManagementCustomerService:IManagementCustomerService
    {

        private readonly IMongoCollection<Customer> customer;

        public ManagementCustomerService(IStockDatabaseSettings settings)
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
