using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TodoApp.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
        public string Role { get; set; } = default!;

        public DateTime CreatedDateTime { get; set; }

    }
}
