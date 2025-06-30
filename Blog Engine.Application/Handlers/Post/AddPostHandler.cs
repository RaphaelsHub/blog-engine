using BlogEngine.Application.Interfaces;
using BlogEngine.Application.Common.Mediator;
using BlogEngine.Commnads;

namespace BlogEngine.Application.Handlers.Post;

public class AddPostHandler(IPostRepository repository) : IRequestHandler<CreatePostCommand, string>
{
    public async Task<string> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new BlogEngine.Core.Entities.Post
        {
            Title = request.CreatePostRequest.Title,
            Content = request.CreatePostRequest.Content
        };

        await repository.CreateAsync(post, cancellationToken);
        return post.Id;
    }
}
