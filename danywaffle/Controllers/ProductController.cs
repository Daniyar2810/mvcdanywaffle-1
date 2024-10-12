using danywaffle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
namespace danywaffle.Controllers;
using SixLabors.ImageSharp.Formats.Webp;
public class ProductController : Controller
{
    private readonly AppDbContext dbContext;

    public ProductController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public IActionResult Ürünler()

    {


        var model = dbContext.Products.ToList();
        return View(model);
    }
    
   

}
