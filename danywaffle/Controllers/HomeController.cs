using Microsoft.AspNetCore.Mvc;

namespace danywaffle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hakkımızda()
        {
            return View();
        }
        public ActionResult Iletişim()
        {
            return View();
        }
    }
}
