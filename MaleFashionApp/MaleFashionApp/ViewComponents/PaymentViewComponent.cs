using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class PaymentViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("Payment");
    }
}