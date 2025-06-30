using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Queries;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Application.Handlers.Post;

public class GetPostByIdHandler(IPostRepository repository) : IRequestHandler<GetPostByIdQuery, PostResponse?>
{
    public async Task<PostResponse?> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
            return null;

        return new PostResponse(
            post.Id,
            post.Title,
            post.Content,
            post.Comments.Select(c => new CommentResponse(c.Id, c.Author, c.Text, c.CreatedAt)).ToList(),
            post.CreatedAt
        );
    }
}
