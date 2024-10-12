using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace danywaffle.Controllers;

public class HomeController : Controller
{
    
    public ActionResult Index()
    {
        return View();
    }
    public ActionResult Ürünler()
    {
        return View();
    }

}