using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites2.Data;
using StLouisSites2.ViewModels.LocationRating;

namespace StLouisSites2.Controllers
{
    public class LocationRatingController : Controller
    {
        private ApplicationDbContext context;

        public LocationRatingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LocationRatingCreateViewModel locationRatingCreateViewModel)
        {
            int ID = LocationRatingCreateViewModel.CreateLocationRating(context, locationRatingCreateViewModel);

            return RedirectToAction(nameof(Index));
        }
    }
}