using MaleFashionApp.Entities;

namespace MaleFashionApp.Dto;

public class CommentDto
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Avatar { get; set; } = "/img/comments/avatar.png";
    public DateTime DateOfPublished  { get; set; }
    public string Message { get; set; } = string.Empty;
    public ICollection<CommentDto> Childs { get; set; } = new List<CommentDto>();
}