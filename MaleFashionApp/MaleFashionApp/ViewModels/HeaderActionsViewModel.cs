using MaleFashionApp.Entities;

namespace MaleFashionApp.ViewModels;

public class HeaderActionsViewModel
{
    public Option Search { get; set; }
    public Option Wishlist { get; set; }
    public Option Cart { get; set; }

    public int CartItemCount { get; set; }
    public decimal TotalPrice { get; set; }
}