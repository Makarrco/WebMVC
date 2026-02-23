using MaleFashionApp.DB;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class ShoppingViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public ShoppingViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }
    public IViewComponentResult Invoke()
    {
        ShoppingViewModel shoppingViewModel = new ShoppingViewModel();

        shoppingViewModel.Shopping = _optionModel.GetShopping();
        shoppingViewModel.ClothStore = _optionModel.GetClothStore();
        shoppingViewModel.TrendShoes = _optionModel.GetShoes();
        shoppingViewModel.Accessories = _optionModel.GetAccessories();
        shoppingViewModel.Sales = _optionModel.GetSales();
        return View("Shopping",  shoppingViewModel);
    }
}