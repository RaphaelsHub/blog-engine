using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Commnads;

namespace BlogEngine.Application.Handlers.Comment;

public class DeleteCommentHandler(ICommentRepository repository) : IRequestHandler<DeleteCommentCommand, bool>
{
    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var dto = request.DeleteCommentRequest;
        return await repository.DeleteAsync(dto.PostId, dto.CommentId, cancellationToken);
    }
}
