using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stock.Operation
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        [BsonElement("CustomerName")]
        [Required]
        public string CustomerName { get; set; }
    }
}
