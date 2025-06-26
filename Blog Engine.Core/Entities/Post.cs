namespace BlogEngine.Core.Entities;

public class Post
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public List<Comment> Comments { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}