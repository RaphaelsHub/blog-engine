using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Commnads;

namespace BlogEngine.Application.Handlers.Post;

public class UpdatePostHandler(IPostRepository repository) : IRequestHandler<UpdatePostCommand, bool>
{
    public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UpdatePostRequest;
        return await repository.UpdateAsync(dto.Id, dto.Title, dto.Content, cancellationToken);
    }
}
