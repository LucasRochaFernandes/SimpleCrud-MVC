using AppMvcArchi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMvcArchi.Controllers;
public class ItemsController : Controller
{
    public ViewResult Overview()
    {
        var item = new Item() { Name = "Test" };
        return View(item);
    }
    public IActionResult Edit(Guid Id)
    {
        return Content($"id = {Id}");
    }
}
