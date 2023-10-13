using Microsoft.AspNetCore.Mvc;

namespace MechanicManager.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Mechanic Manager";
      return View();
    }
  }
}