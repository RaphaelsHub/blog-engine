using BlogEngine.Application.Interfaces;
using BlogEngine.Core.Entities;
using MongoDB.Driver;

namespace BlogEngine.Infrastructure.Repositories;

public class PostRepository(IBlogDbContext blogDbContext) : IPostRepository
{
    private readonly IMongoCollection<Post> _posts = blogDbContext.Posts;

    public async Task CreateAsync(Post post, CancellationToken cancellationToken)
    {
        await _posts.InsertOneAsync(post, cancellationToken: cancellationToken);
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var result = await _posts.DeleteOneAsync(p => p.Id == id, cancellationToken);
        return result.DeletedCount > 0;
    }

    public async Task<List<Post>> GetAllAsync(CancellationToken cancellationToken)
    {
        var projection = Builders<Post>.Projection.Exclude(p => p.Comments);

        return await _posts
            .Find(_ => true)
            .Project<Post>(projection)
            .ToListAsync(cancellationToken);
    }

    public async Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var projection = Builders<Post>.Projection.Exclude(p => p.Comments);

        return await _posts
            .Find(p => p.Id == id)
            .Project<Post>(projection)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(string id, string title, string content, CancellationToken cancellationToken)
    {
        var update = Builders<Post>.Update
            .Set(p => p.Title, title)
            .Set(p => p.Content, content);

        var result = await _posts.UpdateOneAsync(
            p => p.Id == id,
            update,
            cancellationToken: cancellationToken
        );

        return result.ModifiedCount > 0;
    }
}
