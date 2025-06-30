using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Queries;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Application.Handlers.Comment;

public class GetPostCommentHandler(ICommentRepository repository) : IRequestHandler<GetPostCommentQuery, CommentResponse?>
{
    public async Task<CommentResponse?> Handle(GetPostCommentQuery request, CancellationToken cancellationToken)
    {
        var comment = await repository.GetByPostIdAsync(request.PostId, request.CommentId, cancellationToken);

        return comment == null
            ? null
            : new CommentResponse(comment.Id, comment.Author, comment.Text, comment.CreatedAt);
    }
}
