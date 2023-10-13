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
      ViewBag.PageTitle = "Engineer List";
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add an Engineer";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer newAdd)
    {
      _db.Engineers.Add(newAdd);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Engineer Details";
      Engineer targetEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      return View(targetEngineer);
    }

    public ActionResult Edit(int id)
    {
      ViewBag.PageTitle = "Edit Engineer";
      Engineer targetEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      return View(targetEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineerToEdit)
    {
      _db.Engineers.Update(engineerToEdit);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      ViewBag.PageTitle = "Delete Entry";
      Engineer targetEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      return View(targetEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer targetEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      _db.Engineers.Remove(targetEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}