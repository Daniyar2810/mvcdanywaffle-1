using danywaffle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace danywaffle.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly AppDbContext dbContext;

    public ProductController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var model = dbContext.Products.ToList();
        return View(model);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product model)
    {
        dbContext.Products.Add(model);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Edit(Guid id)
    {
        var model = dbContext.Products.Find(id);
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(Product model)
    {
        dbContext.Products.Update(model);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(Guid id)
    {
        var model = dbContext.Products.Find(id);
        dbContext.Products.Remove(model!);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
   
 
}
