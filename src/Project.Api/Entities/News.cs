using MongoDB.Bson.Serialization.Attributes;

namespace Project.Api.Entities
{
    public class News : BaseEntity
    {
        public News(string hat, string title, string text, string author, string img, string link, DateTime publishDate, bool active)
        {
            Hat = hat;
            Title = title;
            Text = text;
            Author = author;
            Img = img;
            Link = link;
            PublishDate = DateTime.Now;
            Active = active;
        }

        [BsonElement("hat")]
        public string Hat { get; private set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; private set; } = string.Empty;

        [BsonElement("text")]
        public string Text { get; private set; } = string.Empty;

        [BsonElement("author")]
        public string Author { get; private set; } = string.Empty;

        [BsonElement("img")]
        public string Img { get; private set; } = string.Empty;

        [BsonElement("link")]
        public string Link { get; private set; } = string.Empty;

        [BsonElement("publishDate")]
        public DateTime PublishDate { get; private set; }

        [BsonElement("active")]
        public bool Active { get; private set; }
    }

}
