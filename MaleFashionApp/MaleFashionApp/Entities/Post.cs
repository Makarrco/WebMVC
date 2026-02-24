namespace MaleFashionApp.Entities;

public enum PostStatuses
{
    New,
    Draft,
    Published,
    Archived
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Slogan { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ImgSrc { get; set; } = string.Empty; 
    public string ImgAlt { get; set; } = string.Empty; 
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Published { get; set; } = null;
    public DateTime Modified { get; set; } = DateTime.Now;
    
    public PostStatuses Status { get; set; } = PostStatuses.New;
    
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}