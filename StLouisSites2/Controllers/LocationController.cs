﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites2.Data;
using StLouisSites2.Models;
using StLouisSites2.ViewModels.Location;
using StLouisSites2.ViewModels.LocationRating;

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
            LocationCreateViewModel locationViewModel = new LocationCreateViewModel(context);
            return View(locationViewModel);
        }
        [HttpPost]
        public IActionResult Create(LocationCreateViewModel locationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(locationViewModel);
            }

            locationViewModel.CreateLocation(context, locationViewModel);
            
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Details(int id)
        {
           
            LocationDetailsViewModel locationDetailsViewModel = LocationDetailsViewModel.GetLocationDetailsViewModel(context, id);
            return View(locationDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(model:new LocationEditViewModel(id, context));
        }

        [HttpPost]
        public IActionResult Edit(LocationEditViewModel locationEditViewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(new LocationEditViewModel());
            }
            locationEditViewModel.Persist(id, context);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}