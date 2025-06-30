using BlogEngine.Application.Common.Mediator;
using BlogEngine.Core.Contracts.Responses;

namespace BlogEngine.Queries;

public record GetPostCommentsQuery(string PostId) : IRequest<List<CommentResponse>>;

public record GetPostCommentQuery(string PostId, string CommentId) : IRequest<CommentResponse?>;
