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

        public Product AddBasket(Product data, string customerName,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int flag = 0;
                Basket customerBasket = basket.Find<Basket>(d => d.CustomerName == customerName).FirstOrDefault();
                if (customerBasket == null)   // initialize 
                {
                    customerBasket = new Basket();
                    customerBasket.CustomerName = customerName;
                    customerBasket.TotalPrice = 0;
                    customerBasket.Items = new List<Product>();
                    basket.InsertOne(customerBasket);
                    flag = 1;
                }

                if (flag == 1)
                    customerBasket = basket.Find<Basket>(d => d.CustomerName == customerName).FirstOrDefault();

                data.TotalUnit -= 1;
                customerBasket.Items.Add(data);
                customerBasket.TotalPrice += data.Price;
                basket.ReplaceOne(d => d.CustomerName == customerName, customerBasket);

            }

            return data;
        }

        public Basket ListBasket(string customerName)
        {
            return basket.Find<Basket>(d => d.CustomerName == customerName).FirstOrDefault();
        }
    }
}
