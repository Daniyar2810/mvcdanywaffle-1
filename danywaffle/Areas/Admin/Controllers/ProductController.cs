using danywaffle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using SixLabors.ImageSharp.Formats.Webp;

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
        FillDropdown();
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Product model)
    {
        Imageselect(model);


        dbContext.Products.Add(model);
        dbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Edit(Guid id)
    {
        
        var model = dbContext.Products.Find(id);
        FillDropdown();
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(Product model)
    {
        Imageselect(model);
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
   
    private void FillDropdown()
    {
        ViewBag.Categories = new SelectList(
            dbContext.Categories.OrderBy(c => c.Name).Select(c => new { c.Id, c.Name }), "Id", "Name"
            );

    }
    private void Imageselect(Product model)
    {
        if (model.ImageFile is not null)
        {
            var image = Image.Load(model.ImageFile.OpenReadStream());
            image.Mutate((p) =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(800, 600),
                    Mode = ResizeMode.Crop
                });
            });
            model.Image = image.ToBase64String(WebpFormat.Instance);

        }
    }
}
