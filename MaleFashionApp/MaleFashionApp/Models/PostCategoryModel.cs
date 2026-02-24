using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class PostCategoryModel
{
    private ClothingShopDbContext _clothingDbContext;
    public PostCategoryModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }
}