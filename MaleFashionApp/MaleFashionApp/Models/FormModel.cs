using MaleFashionApp.DB;
using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class FormModel
{
    private ClothingShopDbContext _clothingDbContext;
    public FormModel(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
    }

    public bool SaveForm(Form form)
    {
        _clothingDbContext.Forms.Add(form);
        
        return _clothingDbContext.SaveChanges() == 1 ? true : false;
    }
}