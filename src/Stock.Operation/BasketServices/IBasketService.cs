using Stock.Operation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Operation.BasketServices
{
    public interface IBasketService
    {
        public Product AddBasket(Product data, string consumerId, int quantity);
        public Basket ListBasket(string consumerId);
        
    }
}
