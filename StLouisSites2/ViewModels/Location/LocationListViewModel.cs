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
        public string Name { get; set; }
        public string Description { get; set; }

        
        public static List<LocationListViewModel>GetLocationListViewModel(ApplicationDbContext context)
        {
            List<Models.Location> locations = context.Locations.ToList();

            List<LocationListViewModel> viewModelLocations = new List<LocationListViewModel>();
            foreach (Models.Location location in locations)
            {
               LocationListViewModel viewModel = new LocationListViewModel();
                viewModel.Name = location.Name;
                viewModel.Description = location.Description;

                viewModelLocations.Add(viewModel);
              
            }
            return viewModelLocations;
            //return locations.Cast<LocationListViewModel>()
                //.Select(location => GetLocationListItemFromLocation(location))
                //.ToList();
            
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
