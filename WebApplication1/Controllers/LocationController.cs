using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLSites.Models;
using WebApplication1.Data;

namespace STLSites.Controllers
{
    public class LocationController : Controller
    {
        //Dependency injection framework
        private ApplicationDbContext context;
        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            //context.Locations is a set (a unique type of list)
            List<Location> locations = context.Locations.ToList();
            return View();
        }

        //Can research adding a service layer, and adding IRepository to hide DB stuff
        //For now, do it ugly in the controller to get it working and refactor it later
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            //Take the location object you got from the controller
            //adding it to the context, which is associated with the DB
            //
            context.Add(location);
            //Call save changes to actually update DB and make it persist
            //only need to save changes once at the end of method
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}