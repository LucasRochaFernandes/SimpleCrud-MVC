using AppMvcArchi.Data;
using AppMvcArchi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMvcArchi.Controllers;
public class ItemsController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index([FromServices] AppDbContext dbContext)
    {
        var items = await dbContext.Items.ToListAsync();
        return View(items);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id", "Name", "Price")] Item item, [FromServices] AppDbContext dbContext)
    {
        if (ModelState.IsValid)
        {
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            throw new Exception("Invalid model state");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, [FromServices] AppDbContext dbContext)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(it => it.Id == id);
        if (item is null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id", "Name", "Price")] Item item, [FromServices] AppDbContext dbContext)
    {
        if (ModelState.IsValid)
        {
            dbContext.Items.Update(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            throw new Exception("Invalid model state");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, [FromServices] AppDbContext dbContext)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(it => it.Id == id);
        if (item is null)
        {
            return NotFound();
        }
        return View(item);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(Guid id, [FromServices] AppDbContext dbContext)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(it => it.Id == id);
        if (item is null)
        {
            return NotFound();
        }
        dbContext.Items.Remove(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
