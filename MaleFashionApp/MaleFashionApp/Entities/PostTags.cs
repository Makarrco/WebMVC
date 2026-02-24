using System.ComponentModel.DataAnnotations.Schema;

namespace MaleFashionApp.Entities;

public class PostTags
{
    public int Id { get; set; }
    [ForeignKey("PostId")]
    public int PostId { get; set; }
    [ForeignKey("TagId")]
    public int TagId { get; set; }
}