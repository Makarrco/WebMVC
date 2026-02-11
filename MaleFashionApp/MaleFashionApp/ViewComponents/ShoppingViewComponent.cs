using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class ShoppingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("Shopping");
    }
}