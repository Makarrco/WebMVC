using MaleFashionApp.DB;
using MaleFashionApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaleFashionApp.Models;

public class CommentModel
{
    private readonly ClothingShopDbContext _clothingDbContext;
    
    public CommentModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }
    
    public List<Comment> GetCommentsTree(int postId)
    {
        var comments = _clothingDbContext.Comments
            .Where(c => c.PostId == postId && c.IsValid)
            .OrderBy(c => c.DateOfPublished)
            .ToList();

        var dict = comments.ToDictionary(c => c.Id);

        foreach (var comment in comments)
        {
            if (comment.ParentId != null && dict.ContainsKey(comment.ParentId.Value))
            {
                dict[comment.ParentId.Value].Childs.Add(comment);
            }
        }

        return comments.Where(c => c.ParentId == null).ToList();
    }
}