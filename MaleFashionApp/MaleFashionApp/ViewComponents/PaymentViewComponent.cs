using MaleFashionApp.DB;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class PaymentViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public PaymentViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }
    public IViewComponentResult Invoke()
    {
        PaymentViewModel payment = new PaymentViewModel();
        
        payment.PayInfo = _optionModel.GetPayInfo();
        payment.PayImage = _optionModel.GetPayImage();
        return View("Payment", payment);
    }
}