using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites2.Data;
using StLouisSites2.Models;

namespace StLouisSites2.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext context;

        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Location> locations = context.Locations.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            context.Add(location);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}