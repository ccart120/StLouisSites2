﻿using Microsoft.EntityFrameworkCore;
using StLouisSites2.Data;
using StLouisSites2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Location
{
    public class LocationListViewModel
    {
        private ApplicationDbContext context;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Models.LocationRating> LocationRatings { get; set; }
        public string AverageRating { get; set; }
        

        public static List<LocationListViewModel>GetLocationListViewModel(ApplicationDbContext context)
        {
            List<Models.Location> locations = context.Locations
                .Include(l => l.LocationRatings)
                .ToList();
            

            List<LocationListViewModel> viewModelLocations = new List<LocationListViewModel>();
            foreach (Models.Location location in locations)
            {
                LocationListViewModel viewModel = new LocationListViewModel();
                viewModel.ID = location.ID;
                viewModel.Name = location.Name;
                viewModel.Description = location.Description;
                viewModel.LocationRatings = location.LocationRatings;
                
                //this gets the LocatingRatings list from context
                //List<Models.LocationRating> tempLocationRatings = context.LocationRatings.ToList();
                //this creates a new instance of a list
                //List<LocationListViewModel> viewModelLocationRatings = new List<LocationListViewModel>();
                //then, 
                //I need to assign the value of tempLocationRating (where I stored list from context)value to my new list (viewModelLocation Ratings of type
                //LocationListViewModel LocationRatings so I can refer to it/use it in the view

                //viewModel.LocationRatings = tempLocationRatings;
                
                
                viewModel.AverageRating = location.LocationRatings.Count > 0 ? Math.Round(location.LocationRatings.Average(x => x.Rating), 2).ToString() : "none";
                
                
                viewModelLocations.Add(viewModel);
              
            }
            return viewModelLocations;
           
            
        }

        //private static LocationListViewModel GetLocationListItemFromLocation(Models.Location location)
        //{
        //    return new LocationListViewModel
        //    {
        //        Name = location.Name,
        //        Description = location.Description
                
        //    };
        //}
    }
}
