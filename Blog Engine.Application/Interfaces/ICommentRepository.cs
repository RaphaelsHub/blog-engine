using BlogEngine.Core.Entities;

namespace BlogEngine.Application.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetByPostIdAsync(string postId, CancellationToken cancellationToken);
    Task<Comment?> GetByPostIdAsync(string postId, string commentId, CancellationToken cancellationToken);
    Task<bool> AddAsync(string postId, Comment comment, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(string postId, string commentId, string newText, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string postId, string commentId, CancellationToken cancellationToken);
}