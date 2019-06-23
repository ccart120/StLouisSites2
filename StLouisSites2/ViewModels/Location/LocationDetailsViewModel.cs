using Microsoft.EntityFrameworkCore;
using StLouisSites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Location
{
    public class LocationDetailsViewModel
    {
        private ApplicationDbContext context;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Models.LocationRating> LocationRatings { get; set; }
        public List<LocationDetailsViewModel> Reviews { get; set; }


        public static int GetLocationDetailsViewModel(ApplicationDbContext context, LocationDetailsViewModel locationDetailsViewModel)
        {
            //make an instance of a view model and then assign it properties
            
            Models.Location location = context.Locations.Single(l => l.ID == locationDetailsViewModel.ID);
            Models.LocationRating locationRating= new Models.LocationRating();
            //we are not assigning the id, we are finding the LocationRating that has the same LocationId
            //as the ID of the Location object that we passed in
            locationRating.LocationID = locationDetailsViewModel.ID;
            //wee need to find all of the Rating that are associated with the Location that had that ID and make
            //them into a list
            //we also need to find all of the Review that are associated with the Location that had that ID and make
            //them into a list
            //so, we can just display these two lists in the view model
            //can we do that?

        }
    }
    //public static List<LocationDetailsViewModel>GetLocationDetailsViewModel(ApplicationDbContext context)
    //{
    //    List<Models.Location> locations = context.Locations
    //        .Include(l => l.LocationRatings)
    //        .ToList();
    //    List<LocationDetailsViewModel> viewModelLocations = new List<LocationDetailsViewModel>();
    //    foreach (Models.Location location in locations)
    //    {
    //        LocationDetailsViewModel viewModel = new LocationDetailsViewModel();
    //        viewModel.ID = location.ID;
    //        viewModel.Name = location.Name;
    //        viewModel.Description = location.Description;
    //        viewModel.LocationRatings = location.LocationRatings;
    //        viewModel.Reviews = location.LocationRatings.Select(r => r.Review).ToList();
    //    }

}
