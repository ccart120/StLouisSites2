using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites2.Data;
using StLouisSites2.Models;
using StLouisSites2.ViewModels.Location;

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
            List<LocationListViewModel> viewModelLocations = LocationListViewModel.GetLocationListViewModel(context);
            return View(viewModelLocations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LocationCreateViewModel locationViewModel)
        {
            int ID = LocationCreateViewModel.CreateLocation(context,locationViewModel);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(LocationDetailsViewModel locationDetailsViewModel)
        {
            return View();
        }
    }
}