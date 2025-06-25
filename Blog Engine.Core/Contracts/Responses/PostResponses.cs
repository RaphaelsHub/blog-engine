namespace BlogEngine.Core.Contracts.Responses;

public record PostResponse(string Id, string Title, string Content, List<CommentResponse> Comments, DateTime CreatedAt);