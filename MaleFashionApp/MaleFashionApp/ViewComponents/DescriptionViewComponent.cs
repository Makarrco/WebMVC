using MaleFashionApp.DB;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class DescriptionViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public DescriptionViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }

    public IViewComponentResult Invoke()
    {
        return View("Description", _optionModel.GetDescription());
    }
}