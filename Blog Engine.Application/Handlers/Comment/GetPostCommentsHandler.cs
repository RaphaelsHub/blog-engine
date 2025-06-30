using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Queries;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Application.Handlers.Comment;

public class GetPostCommentsHandler(ICommentRepository repository) : IRequestHandler<GetPostCommentsQuery, List<CommentResponse>>
{
    public async Task<List<CommentResponse>> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await repository.GetByPostIdAsync(request.PostId, cancellationToken);

        return comments.Select(c => new CommentResponse(c.Id, c.Author, c.Text, c.CreatedAt)).ToList();
    }
}
