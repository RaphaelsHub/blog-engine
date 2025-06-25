using BlogEngine.Common.Mediatr;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Queries;

public record GetAllPostsQuery() : IRequest<List<PostResponse>>;
public record GetPostByIdQuery(string Id) : IRequest<PostResponse?>;