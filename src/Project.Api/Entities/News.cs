﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Project.Api.Entities.Enums;

namespace Project.Api.Entities
{
    public class News : BaseEntity
    {
        public News(string hat, string title, string text, string author, string img,Status status)
        {
            Hat= hat;
            Title= title;
            Text = text;
            Author = author;
            Img = img;            
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

            return Status;
        }
        [BsonElement("hat")]
        public string Hat { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("text")]
        public string Text { get; private set; }

        [BsonElement("author")]
        public string Author { get; private set; }

        [BsonElement("img")]
        public string Img { get; private set; }          

        [BsonElement("date")]
        public DateTime PublishDate { get; private set; }

        [BsonElement("")]
        public Status Status { get; private set; }

    }
}
