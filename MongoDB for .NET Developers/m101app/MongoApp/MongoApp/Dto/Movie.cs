using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoApp.Dto
{
    public class Movie
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("imdb")]
        public string Imdb { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }
}
