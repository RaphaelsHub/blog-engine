namespace BlogEngine.Contracts.Requests;

public record CreatePostRequest(string Title, string Content);

public record UpdatePostRequest(string Id, string Title, string Content);
