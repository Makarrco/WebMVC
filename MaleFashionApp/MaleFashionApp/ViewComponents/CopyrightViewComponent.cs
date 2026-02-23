using MaleFashionApp.DB;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

public class CopyrightViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public CopyrightViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }

    public IViewComponentResult Invoke()
    {
        var option = _optionModel.GetCopyright();
        return View("Copyright", option);
    }
}