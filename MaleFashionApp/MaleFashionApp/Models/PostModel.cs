using MaleFashionApp.DB;
using MaleFashionApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            where tag.Slug == tagSlug 
                  && post.Status == PostStatuses.Published
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

    public List<Post> SearchPosts(string search)
    {
        if (search.IsNullOrEmpty())
            return new List<Post>();

            search = search.ToLower();

            var posts = _clothingDbContext.Posts
                .Where(p =>
                    p.Status == PostStatuses.Published &&
                    (
                        p.Title.ToLower().Contains(search) ||
                        p.Content.ToLower().Contains(search)
                    )
                )
                .OrderBy(p => p.Published)
                .ToList();
            return posts;
    }
    
    

    public Post? GetPostInfo(string slug)
    {
        return _clothingDbContext.Posts
            .Include(p => p.Tags)       
            .Include(p => p.Categories)  
            .FirstOrDefault(p =>
                p.Slug.ToLower() == slug.ToLower() && 
                p.Status == PostStatuses.Published
            );
    }
    
    public int GetTotalPostCount()
    {
        return _clothingDbContext.Posts
            .Count(p => p.Status == PostStatuses.Published);
    }

    public int GetTotalByTag(string tagSlug)
    {
        return (from post in _clothingDbContext.Posts
            join postTag in _clothingDbContext.PostTags on post.Id equals postTag.PostId
            join tag in _clothingDbContext.Tags on postTag.TagId equals tag.Id
            where tag.Slug == tagSlug && post.Status == PostStatuses.Published
            select post).Count();
    }

    public int GetTotalByCategory(string categorySlug)
    {
        return (from post in _clothingDbContext.Posts
            join pc in _clothingDbContext.PostCategories on post.Id equals pc.PostId
            join cat in _clothingDbContext.Categories on pc.CategoryId equals cat.Id
            where cat.Slug == categorySlug && post.Status == PostStatuses.Published
            select post).Count();
    }

    public int GetTotalBySearch(string search)
    {
        search = search.ToLower();

        return _clothingDbContext.Posts.Count(p =>
            p.Status == PostStatuses.Published &&
            (p.Title.ToLower().Contains(search) || p.Content.ToLower().Contains(search)));
    }

    public Post? GetPostById(int postId)
    {
        return _clothingDbContext.Posts.FirstOrDefault(
            p => p.Id == postId && p.Status == PostStatuses.Published
        );
    }
}