using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Commnads;

namespace BlogEngine.Application.Handlers.Comment;

public class AddCommentHandler(ICommentRepository repository) : IRequestHandler<AddCommentCommand, bool>
{
    public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Core.Entities.Comment
        {
            Id = Guid.NewGuid().ToString(),
            Author = request.AddCommentRequest.Author,
            Text = request.AddCommentRequest.Text,
            CreatedAt = DateTime.UtcNow
        };

        return await repository.AddAsync(request.AddCommentRequest.PostId, comment, cancellationToken);
    }
}
