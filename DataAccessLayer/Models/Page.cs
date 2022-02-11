using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Models
{
    [BsonIgnoreExtraElements]
    public class Page
    {
        [BsonElement("BookId")]
        public ObjectId BookId { get; set; }
        [BsonElement("PageText")]
        public string PageText { get; set; }
    }
}
