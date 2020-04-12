using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stock.Model
{
    public class Basket:Customer
    {
        public List<Product> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
