namespace BlogEngine.Contracts.Responses;

public record CommentResponse(string Id, string Author, string Text, DateTime CreatedAt);
