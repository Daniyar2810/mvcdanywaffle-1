using danywaffle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace danywaffle.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly AppDbContext dbContext;

    public CategoryController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var model=dbContext.Categories.ToList();
        return View(model);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category model)
    {
        dbContext.Categories.Add(model);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Edit(Guid id)
    {
        var model = dbContext.Categories.Find(id);
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(Category model)
    {
        dbContext.Categories.Update(model);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(Guid id)
    {
        var model = dbContext.Categories.Find(id);
        dbContext.Categories.Remove(model!);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
