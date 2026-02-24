using MaleFashionApp.Entities;

namespace MaleFashionApp.ViewModels;

public class BlogViewModel
{
    public List<Post> Posts { get; set; } = new List<Post>();

    public List<Category> Categories { get; set; } = new List<Category>();

    public List<Tag> Tags { get; set; } = new List<Tag>();

    // public Pagination { get; set }
}