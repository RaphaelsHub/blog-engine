namespace BlogEngine.Core.Entities;

public class Comment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Author { get; set; } = default!;
    public string Text { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}