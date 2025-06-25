namespace BlogEngine.Core.Contracts.Requests;

public record AddCommentRequest(string PostId, string Author, string Text);

public record UpdateCommentRequest(string PostId, string CommentId, string NewText);

public record DeleteCommentRequest(string PostId, string CommentId);
