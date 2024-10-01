using MongoDB.Bson.Serialization.Attributes;
using Project.Api.Entities.Enums;

namespace Project.Api.Entities
{
    public class Video : BaseEntity
    {
        public Video(string hat, string title, string author, string thumbnail, string url, Status status)
        {
            Hat=hat;
            Title=title;
            Author=author;
            Thumbnail=thumbnail;
            PublishDate = DateTime.Now;
            Url=url;
            Status = status;
        }

        [BsonElement("hat")]
        public string Hat { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("thumbnail")]
        public string Thumbnail { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

    }
}
