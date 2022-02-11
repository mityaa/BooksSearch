using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Models
{
    [BsonIgnoreExtraElements]
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BookId { get; set; }

        [BsonElement("BookFilePath")]
        public string BookFilePath { get; set; }

        [BsonElement("Pages")]
        public IList<Page> Pages { get; set; }


    }
}
