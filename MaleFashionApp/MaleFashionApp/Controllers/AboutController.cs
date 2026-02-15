using MaleFashionApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MaleFashionApp.Controllers;

public class AboutController : Controller
{
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

    // [HttpPost]
    // public IActionResult SaveClientMessage(string Title, string Email, string Message)
    // {
    //     return View();
    // }
    [HttpPost]
    public IActionResult SaveClientMessage(Form clientMessage)
    {
        if (ModelState.IsValid)
        {
            // saving in DB
            return View("Thanks", clientMessage);
        } else {
            return View("Contactus");
        }
    }
}