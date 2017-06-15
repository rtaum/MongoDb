using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace RemoveStudentInfo
{
    public class Student
    {
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("scores")]
        public ICollection<ScoreItem> Scores { get; set; }
    }
}
