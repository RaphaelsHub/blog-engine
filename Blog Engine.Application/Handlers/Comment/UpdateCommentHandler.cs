using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Commnads;

namespace BlogEngine.Application.Handlers.Comment;

public class UpdateCommentHandler(ICommentRepository repository) : IRequestHandler<UpdateCommentCommand, bool>
{
    public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateCommentRequest;
        return await repository.UpdateAsync(dto.PostId, dto.CommentId, dto.NewText, cancellationToken);
    }
}
