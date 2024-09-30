using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Project.Api.Entities.Enums;

namespace Project.Api.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public bool Deleted { get; set; }
        
        public string Slug { get; set; }

        [BsonElement("date")]
        public DateTime PublishDate { get; set; }

        [BsonElement("")]
        public Status Status { get; set; }
    }
}
