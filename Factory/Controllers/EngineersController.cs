using MechanicManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MechanicManager.Controllers
{
  public class EngineersController : Controller
  {
    private readonly MechanicManagerContext _db;

    public EngineersController(MechanicManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }
  }
}