using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace RemoveStudentInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var schoolDb = client.GetDatabase("school");
            //var pipline = PipelineDefinitionBuilder.Match(new PipelineDefinition() {  });

            var studentsCollection = schoolDb.GetCollection<Student>("students");
            var students = studentsCollection
                .Aggregate()
                .Unwind<StudentUnwinded>("Scores")
                .Match<StudentUnwinded>(s => s.Scores.Type == "homework")
                .SortBy<StudentUnwinded>(s => s.Id)
                .ThenBy(s => s.Scores.Score)
                .ToList();

            for (int i = 0; i < students.Count; i += 2)
            {
                var student = students[i];
                studentsCollection.FindOneAndUpdate<Student>(s => s.Id == student.Id,
                    Builders<Student>.Update.PullFilter(a => a.Scores,
                    b => b.Score == student.Scores.Score));
            }

            Console.WriteLine("Hello World!");
        }
    }
}
