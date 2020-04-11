using MongoDB.Driver;
using Stock.Model;
using Stock.Operation.ProductServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Operation
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> product;

        public ProductService(IStockDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            product = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<Product> Get() =>
    product.Find(val => true).ToList();

        public Product Get(string id) =>
            product.Find<Product>(val => val.ProductId == id).FirstOrDefault();

        public Product Create(Product val)
        {
            product.InsertOne(val);
            return val;
        }

        public void Update(string id, Product productIn) =>
            product.ReplaceOne(val => val.ProductId == id, productIn);

        public void Remove(Product productIn) =>
            product.DeleteOne(val => val.ProductId == productIn.ProductId);

        public void Remove(string id) =>
            product.DeleteOne(val => val.ProductId == id);
    }
}
