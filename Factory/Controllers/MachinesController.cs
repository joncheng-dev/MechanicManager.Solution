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
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add a Machine";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine newAdd)
    {
      if(!ModelState.IsValid)
      {
        ViewBag.PageTitle = "Add a Machine";
        return View(newAdd);
      }
      else
      {
        _db.Machines.Add(newAdd);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }      
    }

    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Machine Details";
      Machine targetMachine = _db.Machines.Include(entry => entry.JoinEntities)
                                          .ThenInclude(join => join.Engineer)
                                          .FirstOrDefault(entry => entry.MachineId == id);
      return View(targetMachine);
    }

    public ActionResult Edit(int id)
    {
      ViewBag.PageTitle = "Edit Machine";
      Machine targetMachine = _db.Machines.FirstOrDefault(entry => entry.MachineId == id);
      return View(targetMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machineToEdit)
    {
      if(!ModelState.IsValid)
      {
        ViewBag.PageTitle = "Edit Machine";
        return View(machineToEdit);
      }
      else
      {      
        _db.Machines.Update(machineToEdit);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = machineToEdit.MachineId });
      }
    }

    public ActionResult Delete(int id)
    {
      ViewBag.PageTitle = "Delete Entry";
      Machine targetMachine = _db.Machines.FirstOrDefault(entry => entry.MachineId == id);
      return View(targetMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine targetMachine = _db.Machines.FirstOrDefault(entry => entry.MachineId == id);
      _db.Machines.Remove(targetMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine targetMachine = _db.Machines.FirstOrDefault(entry => entry.MachineId == id);
      // Grab list of Engineers from database. In the view, we'll check the ViewBag.EngineersList if the list is empty
      ViewBag.EngineersList = _db.Engineers.ToList();
      // In the view, the dropdown list will only appear if the above list is not empty
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(targetMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine targetMachine, int engineerId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => join.EngineerId == engineerId && join.MachineId == targetMachine.MachineId);
      #nullable disable
      if (joinEntity == null && engineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = targetMachine.MachineId, EngineerId = engineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = targetMachine.MachineId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.MachineId });
    }
  }
}