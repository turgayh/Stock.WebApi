using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Stock.Model
{
    public class Product 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Brand { get; set; }
        public int TotalUnit { get; set; }
    }
}
