using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stock.Model
{
    public class Basket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ConsumerId { get; set; }

        public List<Product> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
