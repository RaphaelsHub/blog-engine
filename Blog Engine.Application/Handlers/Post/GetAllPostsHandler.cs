using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Queries;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Application.Handlers.Post;

public class GetAllPostsHandler(IPostRepository repository) : IRequestHandler<GetAllPostsQuery, List<PostResponse>>
{
    public async Task<List<PostResponse>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await repository.GetAllAsync(cancellationToken);

        return posts.Select(p => new PostResponse(
            p.Id,
            p.Title,
            p.Content,
            p.Comments.Select(c => new CommentResponse(c.Id, c.Author, c.Text, c.CreatedAt)).ToList(),
            p.CreatedAt
        )).ToList();
    }
}
