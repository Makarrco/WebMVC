using MaleFashionApp.DB;
using MaleFashionApp.Models;
using MaleFashionApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.ViewComponents;

public class HeaderOptionsViewComponent : ViewComponent
{
    private readonly ClothingShopDbContext _clothingDbContext;
    private OptionModel _optionModel;

    public HeaderOptionsViewComponent(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _optionModel = new OptionModel(clothingDbContext);
    }

    public IViewComponentResult Invoke()
    {
        var model = new HeaderActionsViewModel
        {
            Search = _optionModel.GetSearch(),
            Wishlist = _optionModel.GetWishlist(),
            Cart = _optionModel.GetCart(),
            CartItemCount = 0,
            TotalPrice = 0
        };

        return View("HeaderOptions", model);
    }
}

// _cartService = cartService;
// private readonly CartService _cartService; // You need this