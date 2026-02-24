using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class TagModel
{
    private ClothingShopDbContext _clothingDbContext;
    public TagModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }

    public List<Tag> GetNotEmptytagList()
    {
        return _clothingDbContext.Tags.Where(tag => _clothingDbContext.PostTags.Any(pt => pt.TagId == tag.Id)).ToList();
    }
}