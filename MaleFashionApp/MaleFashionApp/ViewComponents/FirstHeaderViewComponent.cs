using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class FirstHeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("FirstHeader");
    }
}