using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class NewLetterViewComponent :  ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("NewLetter");
    }
}