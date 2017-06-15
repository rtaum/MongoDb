using MongoDB.Bson.Serialization.Attributes;

namespace RemoveStudentInfo
{
    public class ScoreItem
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("score")]
        public double Score { get; set; }
    }
}
