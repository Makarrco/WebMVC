using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class PostTagModel
{
    private ClothingShopDbContext _clothingDbContext;
    public PostTagModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }
}