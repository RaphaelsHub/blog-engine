using BlogEngine.Core.Entities;

namespace BlogEngine.Application.Interfaces;

public interface IPostRepository
{
    Task CreateAsync(Post post, CancellationToken cancellationToken);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<List<Post>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> UpdateAsync(string id, string title, string content, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
}
