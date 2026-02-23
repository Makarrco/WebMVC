using MaleFashionApp.DB;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents
{
    public class LogoSiteViewComponent : ViewComponent
    {
        
        private readonly ClothingShopDbContext _clothingDbContext;
        
        private OptionModel _optionModel;

        public LogoSiteViewComponent(ClothingShopDbContext clothingDbContext)
        {
            _clothingDbContext = clothingDbContext;
            _optionModel = new OptionModel(clothingDbContext);
        }
        public IViewComponentResult Invoke()
        {
            return View("LogoSite", _optionModel.GetLogo());
        }
    }
}