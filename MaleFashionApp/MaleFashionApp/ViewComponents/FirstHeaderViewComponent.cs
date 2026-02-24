using MaleFashionApp.DB;
using MaleFashionApp.Models;
using MaleFashionApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class FirstHeaderViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public FirstHeaderViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }
    public IViewComponentResult Invoke()
    {
        FirstHeaderViewModel firstHeaderViewModel = new FirstHeaderViewModel();

        firstHeaderViewModel.SignIn = _optionModel.GetSignIn();
        firstHeaderViewModel.FAQ = _optionModel.GetFAQ();
        firstHeaderViewModel.Currencies = _optionModel.GetCurrencies();

        return View("FirstHeader", firstHeaderViewModel);
    }
}