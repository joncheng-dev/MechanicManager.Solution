using Microsoft.AspNetCore.Mvc;
using MechanicManager.Models;

namespace MechanicManager.Controllers
{
  public class HomeController : Controller
  {
    private readonly MechanicManagerContext _db;

    public HomeController(MechanicManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Mechanic Manager";
      Engineer[] engineersArray = _db.Engineers.ToArray();
      Machine[] machinesArray = _db.Machines.ToArray();
      Dictionary<object[], object[]> model = new Dictionary<object[], object[]>();
      model.Add("engineers", engineersArray);
      model.Add("machines", machinesArray);
      return View(model);
    }
  }
}