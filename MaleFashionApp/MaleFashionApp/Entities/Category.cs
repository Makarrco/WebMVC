using System.ComponentModel.DataAnnotations.Schema;

namespace MaleFashionApp.Entities;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ImgSrc { get; set; } = "/img/blog/categories/product-sale.png"; 
    public string ImgAlt { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    [ForeignKey("ParentId")]
    public int? ParentId { get; set; } = null;
    public ICollection<Category> Childs { get; set; } = new List<Category>();
}
// img/categories/trends.jpg