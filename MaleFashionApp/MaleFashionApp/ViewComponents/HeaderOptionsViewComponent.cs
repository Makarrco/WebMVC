using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class HeaderOptionsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("HeaderOptions");
    }
}