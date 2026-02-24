using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class CategoryModel
{
    private ClothingShopDbContext _clothingDbContext;
    public CategoryModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }

    public List<Category> GetCategoryTree()
    {
        var parentCategories = _clothingDbContext.Categories.Where(c => c.ParentId == null).ToList();
        foreach (Category oneCat in parentCategories)
        {
            BuildCategoryTree(oneCat);
        }
        return parentCategories;
    }

    private void BuildCategoryTree(Category oneCat)
    {
        var childCategories = _clothingDbContext.Categories.Where(c => c.ParentId == oneCat.Id).ToList();
        foreach (Category childCat in childCategories)
        {
            oneCat.Childs.Add(childCat);
            BuildCategoryTree(childCat);
        }
    }
}