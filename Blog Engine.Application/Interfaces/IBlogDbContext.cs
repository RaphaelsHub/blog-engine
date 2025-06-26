using BlogEngine.Core.Entities;
using MongoDB.Driver;

namespace BlogEngine.Application.Interfaces;


public interface IBlogDbContext
{
    IMongoCollection<Post> Posts { get; }
}