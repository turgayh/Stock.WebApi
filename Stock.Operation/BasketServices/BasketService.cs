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
        private readonly IMongoCollection<Basket> basket;

        public BasketService(IStockDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            basket = database.GetCollection<Basket>(settings.BasketCollectionName);
        }

        public Product AddBasket(Product data, string consumerId,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Basket consumerBasket = basket.Find<Basket>(d => d.ConsumerId == consumerId).FirstOrDefault();
                consumerBasket.Items.Add(data);
                consumerBasket.TotalPrice += data.Price;
            }
            return data;
        }

        public Basket ListBasket(string consumerId)
        {
            return basket.Find<Basket>(d => d.ConsumerId == consumerId).FirstOrDefault();
        }
    }
}
