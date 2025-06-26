using BlogEngine.Application.Interfaces;
using BlogEngine.Core.Entities;

namespace BlogEngine.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    public PostRepository()
    {
    }

    public Task CreateAsync(Post post, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Post>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(string id, string title, string content, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}