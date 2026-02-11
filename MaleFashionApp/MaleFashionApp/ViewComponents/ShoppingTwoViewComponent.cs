using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class ShoppingTwoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("ShoppingTwo");
    }
}