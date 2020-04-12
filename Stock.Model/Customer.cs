using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stock.Model
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ConsumerId { get; set; }
        public string CustomerName { get; set; }
    }
}
