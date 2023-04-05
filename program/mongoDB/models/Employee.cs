using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication4.models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

    }
}
