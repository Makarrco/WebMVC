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
            Title = "Pages",
            Href = "/pages",
            Order = 3,
            ParentId = null
        });
        _navigate.Add(new Navigate()
        {
            Id = 4,
            Title = "Blog",
            Href = "/blog",
            Order = 4,
            ParentId = null
        });
        _navigate.Add(new Navigate()
        {
            Id = 5,
            Title = "Contacts",
            Href = "/About/ContactUs",
            Order = 5,
            ParentId = null
        });
        
        _navigate[2].Childs.Add(new Navigate()
        {
            Id = 6,
            Title = "About Us",
            Href = "/About",
            Order = 1,
            ParentId = 3
        });
        _navigate[2].Childs.Add(new Navigate()
        {
            Id = 7,
            Title = "Shop Details",
            Href = "/blog/shopdetails",
            Order = 2,
            ParentId = 3
        });
        _navigate[2].Childs.Add(new Navigate()
        {
            Id = 8,
            Title = "Shopping Cart",
            Href = "/blog/shopcart",
            Order = 3,
            ParentId = 3
        });
        _navigate[2].Childs.Add(new Navigate()
        {
            Id = 9,
            Title = "Check out",
            Href = "/blog/checkout",
            Order = 4,
            ParentId = 3
        });
        _navigate[2].Childs.Add(new Navigate()
        {
            Id = 10,
            Title = "Blog Details",
            Href = "/blog/blogdetails",
            Order = 5,
            ParentId = 3
        });
    }
    
    public IViewComponentResult Invoke()
    {
        return View("HeaderBar", _navigate);
    }
}