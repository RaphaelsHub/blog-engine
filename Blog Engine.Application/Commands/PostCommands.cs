using BlogEngine.Common.Mediatr;
using BlogEngine.Core.Contracts.Requests;

namespace BlogEngine.Commnads;

public record CreatePostCommand(CreatePostRequest CreatePostRequest) : IRequest<string>;

public record UpdatePostCommand(UpdatePostRequest UpdatePostRequest) : IRequest<bool>;

public record DeletePostCommand(string Id) : IRequest<bool>;