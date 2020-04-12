using MongoDB.Driver;
using Stock.Operation.DatabaseHelper;
using System.Collections.Generic;

namespace Stock.Operation.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IMongoCollection<Basket> basket;

        public BasketService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            basket = database.GetCollection<Basket>(settings.BasketCollectionName);
        }

        public Product AddBasket(Product data, string customerId,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                
                Basket customerBasket = basket.Find<Basket>(d => d.CustomerId== customerId).FirstOrDefault();
                if (customerBasket == null) 
                {
                    Basket temp = new Basket();
                    temp.CustomerName = customerId;
                    temp.TotalPrice = 0;
                    temp.Items = new List<Product>();
                    basket.InsertOne(temp);
                    customerBasket = basket.Find<Basket>(d => d.CustomerId == customerId).FirstOrDefault();
                }
                data.TotalUnit -= 1;
                customerBasket.Items.Add(data);
                customerBasket.TotalPrice += data.Price;
                basket.ReplaceOne(d => d.CustomerName == customerId,customerBasket);
            }

            return data;
        }

        public Basket ListBasket(string consumerId)
        {
            return basket.Find<Basket>(d => d.CustomerId == consumerId).FirstOrDefault();
        }
    }
}
