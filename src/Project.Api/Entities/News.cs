using MongoDB.Bson.Serialization.Attributes;
using Project.Api.Entities.Enums;

namespace Project.Api.Entities
{
    public class News : BaseEntity
    {
        public News(string hat, string title, string text, string author, string img, string link,  Status status)
        {
            Hat = hat;
            Title = title;
            Text = text;
            Author = author;
            Img = img;
            Link = link;
            PublishDate = DateTime.Now;
            Status = status;
        }

        public Status ChangeStatus(Status status)
        {
            switch (status) 
            {
                case Status.Active:
                    status = Status.Active;
                    break;
                case Status.Inactive:
                    status = Status.Inactive;
                    break;
                case Status.Draft:
                    status = Status.Draft;
                    break;
            }

            return status;
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
        public Status Status { get; private set; }
    }

}
