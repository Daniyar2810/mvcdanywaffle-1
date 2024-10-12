using danywaffle.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using SixLabors.ImageSharp.Formats.Webp;

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
       
        ViewBag.Category = dbContext.Categories.ToList<Category>();
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category model)
    {
        Imagesel(model);
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
        Imagesel(model);


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
  private void Imagesel(Category model)
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
