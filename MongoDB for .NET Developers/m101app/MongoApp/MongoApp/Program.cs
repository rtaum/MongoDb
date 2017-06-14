using MongoApp.Dto;
using MongoDB.Driver;
using System;

namespace MongoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoClient = new MongoClient();
            var videoDb = mongoClient.GetDatabase("video");
            var movies = videoDb.GetCollection<Movie>("movies").Find<Movie>(a => a.Year == 2015).Limit(5).Project(a => new { a.Title, a.Year }).ToList();
            foreach(var movie in movies)
            {
                var aaa = movie.Title;
            }
        }
    }
}
