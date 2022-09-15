using Microsoft.AspNetCore.Mvc;

namespace PracticeMicroservice.Web.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
