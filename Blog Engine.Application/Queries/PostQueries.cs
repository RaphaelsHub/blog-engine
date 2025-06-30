using BlogEngine.Application.Common.Mediator;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Queries;

public record GetAllPostsQuery() : IRequest<List<PostResponse>>;
public record GetPostByIdQuery(string Id) : IRequest<PostResponse?>;