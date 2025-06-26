using BlogEngine.Application.Interfaces;
using BlogEngine.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BlogEngine.Infrastructure.Context;

public class BlogDbContext : IBlogDbContext
{
    private readonly IMongoDatabase _database;
    public BlogDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["Mongo:ConnectionString"]);
        _database = client.GetDatabase(configuration["Mongo:Database"]);
    }

    public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");
}