using MongoDB.Bson.Serialization.Attributes;

namespace RemoveStudentInfo
{
    public class StudentUnwinded
    {
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("scores")]
        public ScoreItem Scores { get; set; }
    }
}
