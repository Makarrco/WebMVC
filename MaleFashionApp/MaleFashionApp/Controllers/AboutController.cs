using System.Diagnostics;
using MaleFashionApp.DB;
using MaleFashionApp.Entities;
using MaleFashionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.Controllers;

public class AboutController : Controller
{
    private ClothingShopDbContext _clothingDbContext;
    
    private FormModel _formModel;
    public AboutController(ClothingShopDbContext clothingDbContext)
    {
        _clothingDbContext = clothingDbContext;
        _formModel = new FormModel(clothingDbContext);
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }

    
    [HttpPost]
    public IActionResult SaveClientMessage(Form clientMessage)
    {
        if (ModelState.IsValid)
        {
            if (_formModel.SaveForm(clientMessage))
            {
                return View("Thanks",  clientMessage);
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                
            }
        } else {
            return View("Contactus");
        }
    }
}