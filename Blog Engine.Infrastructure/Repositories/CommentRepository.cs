using BlogEngine.Application.Interfaces;
using BlogEngine.Core.Entities;

namespace BlogEngine.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    public CommentRepository()
    {
    }

    public Task<bool> AddAsync(string postId, Comment comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string postId, string commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> GetByPostIdAsync(string postId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetByPostIdAsync(string postId, string commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(string postId, string commentId, string newText, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}