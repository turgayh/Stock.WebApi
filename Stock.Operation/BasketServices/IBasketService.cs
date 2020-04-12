using Stock.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Operation.BasketServices
{
    public interface IBasketService
    {
        public Task<List<OrderItem>> CheckBasket();
        public Task<OrderItem> AddBasket(OrderItem data);
        
    }
}
