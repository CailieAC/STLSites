using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLSites.Models;
using STLSites.Data;
using WebApplication1.Data;
using STLSites.ViewModels.Location;

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
            //Below is how it was from class, to do entity framework/database stuff
            List<Location> locations = context.Locations.ToList();

            //Below is how we did it before with just ViewModels
            //var locations = LocationListItemViewModel.GetLocationList();
            return View(locations);

        }

        //Can research adding a service layer, and adding IRepository to hide DB stuff
        //For now, do it ugly in the controller to get it working and refactor it later
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel model)
        {
            //Take the location object you got from the controller
            //adding it to the context, which is associated with the DB
            //
            model.Persist(context);
            //context.add assigns the next id to the model from the database
            //does context.add have a return type?
            context.Add(model);
            //Call save changes to actually update DB and make it persist
            //only need to save changes once at the end of method
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}