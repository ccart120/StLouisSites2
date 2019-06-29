using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites2.Data;
using StLouisSites2.ViewModels.Category;

namespace StLouisSites2.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
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
        public IActionResult Create(CategoryCreateViewModel categoryCreateViewModel)
        {
            int ID = CategoryCreateViewModel.CreateCategory(context, categoryCreateViewModel);
            return RedirectToAction("Index", "Location");
            //return View(categoryCreateViewModel);
        }
    }
}