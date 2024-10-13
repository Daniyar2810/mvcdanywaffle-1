using Microsoft.AspNetCore.Mvc;

namespace danywaffle.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
