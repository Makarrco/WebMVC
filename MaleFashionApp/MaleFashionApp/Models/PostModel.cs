using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class PostModel
{
    private ClothingShopDbContext _clothingDbContext;
    public PostModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }

    public List<Post> GetPosts(int count, int offset)
    {
        return  _clothingDbContext.Posts
            .Where(p => p.Status == PostStatuses.Published)
            .OrderBy(p => p.Published)
            .Skip(offset)
            .Take(count)
            .ToList();
    }

    public List<Post> GetPostsByTagSlug(string tagSlug)
    {
        var posts = from post in _clothingDbContext.Posts
            join postTag in _clothingDbContext.PostTags 
                on post.Id equals postTag.PostId
            join tag in _clothingDbContext.Tags 
                on postTag.TagId equals tag.Id
            where post.Slug == tagSlug && post.Status == PostStatuses.Published
                orderby post.Published
                select post;
        return posts.ToList();
    }

    public List<Post> GetPostsByCategorySlug(string categorySlug)
    {
        var posts = from post in _clothingDbContext.Posts
            join PostCategory in _clothingDbContext.PostCategories
                on post.Id equals PostCategory.PostId
            join category in _clothingDbContext.Categories
                on PostCategory.CategoryId equals category.Id
            where category.Slug == categorySlug && post.Status == PostStatuses.Published
            orderby post.Published
            select post;
        return posts.ToList();
    }
}