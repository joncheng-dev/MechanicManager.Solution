using MechanicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MechanicManager.Controllers
{
  public class MachinesController : Controller
  {
    private readonly MechanicManagerContext _db;

    public MachinesController(MechanicManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Machine List";
      return View();
    }
  }
}