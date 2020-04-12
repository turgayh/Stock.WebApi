using MongoDB.Driver;
using Stock.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Operation.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IMongoCollection<OrderItem> basket;

        public BasketService(IStockDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            basket = database.GetCollection<OrderItem>(settings.StockCollectionName);
        }

        public Task<OrderItem> AddBasket(OrderItem data)
        {
                throw new NotImplementedException();
        }

        public Task<List<OrderItem>> CheckBasket()
        {
            throw new NotImplementedException();
        }
    }
}
