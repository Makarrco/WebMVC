using MaleFashionApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class HeaderBarViewComponent : ViewComponent
{
    private List<Navigate> _navigate;

    public HeaderBarViewComponent()
    {
        _navigate = new List<Navigate>();
        
        _navigate.Add(new Navigate()
        {
            Id = 1,
            Title = "Home",
            Href = "/",
            Order = 1,
            ParentId = null
        });
        _navigate.Add(new Navigate()
        {
            Id = 2,
            Title = "Shop",
            Href = "/shop",
            Order = 2,
            ParentId = null
        });
        _navigate.Add(new Navigate()
        {
            Id = 3,
            Title = "Blog",
            Href = "/blog",
            Order = 3,
            ParentId = null
        });
        _navigate.Add(new Navigate()
        {
            Id = 4,
            Title = "Contacts",
            Href = "/contacts",
            Order = 4,
            ParentId = null
        });
        
        _navigate[2].Childs.Add(new Navigate()
        {
            Id = 5,
            Title = "Blog1",
            Href = "/blog/one",
            Order = 1,
            ParentId = 1
        });
    }
    
    public IViewComponentResult Invoke()
    {
        return View("HeaderBar", _navigate);
    }
}