using MaleFashionApp.DB;
using MaleFashionApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaleFashionApp.ViewComponents
{
    public class MainNavigationViewComponent : ViewComponent
    {
        private readonly ClothingShopDbContext _context;

        public MainNavigationViewComponent(ClothingShopDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var navigations = _context.Navigations
                .Where(x => x.ParentId == null)
                .Include(x => x.Childs)
                .ToList();

            return View(navigations);
        }
    }
}