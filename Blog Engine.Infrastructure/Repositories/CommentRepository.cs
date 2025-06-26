using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogEngine.Application.Interfaces;
using BlogEngine.Core.Entities;
using MongoDB.Driver;

namespace BlogEngine.Infrastructure.Repositories;

public class CommentRepository(IBlogDbContext blogDbContext) : ICommentRepository
{
    private readonly IMongoCollection<Post> _posts = blogDbContext.Posts;

    public async Task<bool> AddAsync(string postId, Comment comment, CancellationToken cancellationToken)
    {
        var post = await _posts.Find(p => p.Id == postId).FirstOrDefaultAsync(cancellationToken);
        if (post == null) return false;

        post.Comments.Add(comment);
        var result = await _posts.ReplaceOneAsync(p => p.Id == postId, post, cancellationToken: cancellationToken);

        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string postId, string commentId, CancellationToken cancellationToken)
    {
        var post = await _posts.Find(p => p.Id == postId).FirstOrDefaultAsync(cancellationToken);
        if (post == null) return false;

        var comment = post.Comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null) return false;

        post.Comments.Remove(comment);
        var result = await _posts.ReplaceOneAsync(p => p.Id == postId, post, cancellationToken: cancellationToken);

        return result.ModifiedCount > 0;
    }

    public async Task<List<Comment>> GetByPostIdAsync(string postId, CancellationToken cancellationToken)
    {
        var comments = await _posts
            .Find(p => p.Id == postId)
            .Project(p => p.Comments)
            .FirstOrDefaultAsync(cancellationToken);

        return comments ?? new List<Comment>();
    }

    public async Task<Comment?> GetByPostIdAsync(string postId, string commentId, CancellationToken cancellationToken)
    {
        var post = await _posts.Find(p => p.Id == postId).FirstOrDefaultAsync(cancellationToken);
        return post?.Comments.FirstOrDefault(c => c.Id == commentId);
    }

    public async Task<bool> UpdateAsync(string postId, string commentId, string newText, CancellationToken cancellationToken)
    {
        var post = await _posts.Find(p => p.Id == postId).FirstOrDefaultAsync(cancellationToken);
        if (post == null) return false;

        var comment = post.Comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null) return false;

        comment.Text = newText;
        var result = await _posts.ReplaceOneAsync(p => p.Id == postId, post, cancellationToken: cancellationToken);

        return result.ModifiedCount > 0;
    }
}
