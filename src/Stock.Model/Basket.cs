using System.Collections.Generic;
namespace Stock.Operation
{
    public class Basket : Customer
    {
        public List<Product> Items { get; set; }

        public Dictionary<string, int> ProductQuantity {get;set;}
        public decimal TotalPrice { get; set; }
    }
}
