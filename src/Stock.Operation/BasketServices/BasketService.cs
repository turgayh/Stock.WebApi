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

        public string AddBasket(Product data, string customerName,int quantity)
        {
            string productId = data.ProductId;
            int productTotalUnit = data.TotalUnit;
            Basket customerBasket;

            customerBasket = basket.Find<Basket>(d => d.CustomerName == customerName).FirstOrDefault();
            if (customerBasket == null)   // initialize 
            {
                customerBasket = new Basket();
                customerBasket.CustomerName = customerName;
                customerBasket.TotalPrice = 0;
                customerBasket.ProductQuantity = new Dictionary<string, int>();
                customerBasket.Items = new List<Product>();
                basket.InsertOne(customerBasket);
                customerBasket = basket.Find<Basket>(d => d.CustomerName == customerName).FirstOrDefault();
            }
            if (customerBasket.ProductQuantity.ContainsKey(productId) == false)
                customerBasket.ProductQuantity.Add(productId, 0);

            for (int i = 0; i < quantity; i++)
            {
                customerBasket.Items.Add(data);
                customerBasket.TotalPrice += data.Price;
                customerBasket.ProductQuantity[productId] += 1;
                if (customerBasket.ProductQuantity[productId] > productTotalUnit)
                    break;

                basket.ReplaceOne(d => d.CustomerName == customerName, customerBasket);

 
            }

            return customerBasket.CustomerId;
        }

        public Basket ListBasket(string customerName)
        {
            return basket.Find<Basket>(d => d.CustomerName == customerName).FirstOrDefault();
        }
    }
}
