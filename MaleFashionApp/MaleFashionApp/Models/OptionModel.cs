using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class OptionModel
{
    private ClothingShopDbContext _clothingDbContext;
    public OptionModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }

    public IEnumerable<Option> GetHeaderInfo()
    {
        return _clothingDbContext.Options.Where(o => o.Relation == "header").OrderBy(o => o.Order).ToList();
    }
    
    public IEnumerable<Option> GetTopLinks()
    {
        return _clothingDbContext.Options.Where(o => o.Relation == "header-top-links").OrderBy(o => o.Order).ToList();
    }
    
    public Option? GetLogo()
    {
        return _clothingDbContext.Options.FirstOrDefault(o => o.Name == "logo");
    }

    private Option? GetOptionByName(string name)
    {
        return  _clothingDbContext.Options.FirstOrDefault(o => o.Name.ToUpper() == name.ToUpper());
    }
    public Option GetOptionById(int id)
    {
        return  _clothingDbContext.Options.FirstOrDefault(o => o.Id == id);
    }

    public Option? GetDescription()
    {
        return GetOptionByName("description");
    }
    public Option? GetSignIn()
    {
        return GetOptionByName("Sign-In");
    }

    public Option? GetFAQ()
    {
        return GetOptionByName("FAQ");
    }
    public Option? GetCopyright()
    {
        return GetOptionByName("Copyright");
    }
    public IEnumerable<Option> GetCurrencies()
    {
        return _clothingDbContext.Options
            .Where(o => o.Relation == "currency")
            .OrderBy(o => o.Order)
            .ToList();
    }

    public Option GetPayInfo()
    {
        return GetOptionByName("payment_links");
    }
    public Option GetPayImage()
    {
        return GetOptionByName("payImage");
    }
    public Option GetShopping()
    {
        return GetOptionByName("shopping_title");
    }
    public Option GetClothStore()
    {
        return GetOptionByName("Clothing Store");
    }
    public Option GetShoes()
    {
        return GetOptionByName("Trending Shoes");
    }
    public Option GetAccessories()
    {
        return GetOptionByName("Accessories");
    }
    public Option GetSales()
    {
        return GetOptionByName("Sale");
    }
    public Option GetContactUs()
    {
        return GetOptionByName("Contact Us");
    }

    public Option GetPaymentMethods()
    {
        return GetOptionByName("Payment Methods");
    }

    public Option GetDelivery()
    {
        return GetOptionByName("Delivery");
    }

    public Option GetReturnExchanges()
    {
        return GetOptionByName("Return & Exchanges");
    }
    public Option GetSearch()
    {
        return GetOptionByName("Search");
    }

    public Option GetWishlist()
    {
        return GetOptionByName("Wishlist");
    }

    public Option GetCart()
    {
        return GetOptionByName("Cart");
    }
    
    public IEnumerable<Option> GetBarOptions()
    {
        return _clothingDbContext.Options.Where(o => o.Relation == "header-bar-option").OrderBy(o => o.Order).ToList();
    }
    
    

    
    
    
    
}