using Microsoft.AspNetCore.Mvc;

namespace danywaffle.Areas.Admin.Controllers;
[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult AdminAnaSayfa()
    {
        return View();
    }
}
