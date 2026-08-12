using Microsoft.AspNetCore.Mvc;

namespace AspNetWeek2.Mvc.Controllers
{
public class HomeController : Controller
{
public IActionResult Index()
{
return View();
}
}
}
