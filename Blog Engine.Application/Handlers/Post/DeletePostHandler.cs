using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Commnads;

namespace BlogEngine.Application.Handlers.Post;

public class DeletePostHandler(IPostRepository repository) : IRequestHandler<DeletePostCommand, bool>
{
    public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        return await repository.DeleteAsync(request.Id, cancellationToken);
    }
}
