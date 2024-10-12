using danywaffle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
namespace danywaffle.Controllers;

public class CategoryController : Controller
{
    private readonly AppDbContext dbContext;

    public CategoryController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IActionResult Menü()

    {


        var model = dbContext.Categories.ToList();
        return View(model);
    }
    
}
