using MaleFashionApp.Dto;
using MaleFashionApp.Entities;

public static class CommentDtoHelper
{
    public static List<CommentDto> Convert(List<Comment> comments)
    {
        return comments.Select(ConvertOne).ToList();
    }

    private static CommentDto ConvertOne(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Login = comment.Login,
            Email = comment.Email,
            Avatar = comment.Avatar,
            DateOfPublished = comment.DateOfPublished,
            Message = comment.Message,
            Childs = comment.Childs.Any()
                ? comment.Childs.Select(ConvertOne).ToList()
                : new List<CommentDto>()
        };
    }
}