using System.ComponentModel.DataAnnotations.Schema;

namespace MaleFashionApp.Entities;

public class PostCategories
{
    public int Id { get; set; }
    [ForeignKey("PostId")]
    public int PostId { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
}