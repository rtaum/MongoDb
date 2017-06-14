using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Homework_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var students = client.GetDatabase("students");
            var collections = students.GetCollection<BsonDocument>("grades");
            var grades = collections.Find<BsonDocument>("{}")
                .Sort("{student_id : 1, score : 1}")
                .ToList();

            var lowestScores = new List<ObjectId>();
            for(int i = 0; i < grades.Count; i += 4)
            {
                lowestScores.Add(grades[i]["_id"].AsObjectId);
            }

            var a = lowestScores.Count;
            var objectIdFilter = Builders<BsonDocument>.Filter.In("_id", lowestScores);
            var count = collections.DeleteMany(objectIdFilter);
        }
    }
}
