using BlogEngine.Common.Mediatr;
using BlogEngine.Core.Contracts.Requests;

namespace BlogEngine.Commnads;

public record AddCommentCommand(AddCommentRequest AddCommentRequest) : IRequest<bool>;
public record UpdateCommentCommand(UpdateCommentRequest UpdateCommentRequest) : IRequest<bool>;
public record DeleteCommentCommand(DeleteCommentRequest DeleteCommentRequest) : IRequest<bool>;