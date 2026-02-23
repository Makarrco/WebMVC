using MaleFashionApp.DB;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class ShoppingTwoViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public ShoppingTwoViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }

    public IViewComponentResult Invoke()
    {
        ShoppingTwoViewModel viewModel = new ShoppingTwoViewModel();

        viewModel.Shopping = _optionModel.GetShopping();
        viewModel.ContactUs = _optionModel.GetContactUs();
        viewModel.PaymentMethods = _optionModel.GetPaymentMethods();
        viewModel.Delivery = _optionModel.GetDelivery();
        viewModel.ReturnExchanges = _optionModel.GetReturnExchanges();

        return View("ShoppingTwo", viewModel);
    }
}