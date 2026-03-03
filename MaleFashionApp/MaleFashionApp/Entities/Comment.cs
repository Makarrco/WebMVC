namespace MaleFashionApp.Entities;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Avatar { get; set; } = "/img/comments/avatar.png";
    public bool IsValid { get; set; } = false;
    public DateTime DateOfPublished  { get; set; }
    public string Message { get; set; } = string.Empty;
    public int? ParentId { get; set; } = null;
    public ICollection<Comment> Childs { get; set; } = new List<Comment>();
}