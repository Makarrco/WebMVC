using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents
{
    public class LogoSiteViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("LogoSite");
        }
    }
}