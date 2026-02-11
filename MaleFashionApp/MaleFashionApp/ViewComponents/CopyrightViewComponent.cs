using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class CopyrightViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("Copyright");
    }
}