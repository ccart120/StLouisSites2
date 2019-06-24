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
        public List<Models.LocationRating> Reviews { get; set; }


        public LocationDetailsViewModel GetLocationDetailsViewModel(ApplicationDbContext context, LocationDetailsViewModel locationDetailsViewModel)
        {
            //make an instance of a view model //we are not assigning the id, we are finding the LocationRating that has the same LocationId
            //as the ID of the Location object that we (passed in) and then assign it properties
            //we are not assigning the id, we are finding the LocationRating that has the same LocationId
            //as the ID of the Location object that we passed in
            locationDetailsViewModel = new LocationDetailsViewModel();
            Models.Location location = context.Locations.Include(l => l.Name)
                .Include(l => l.Description)
                .Single(l => l.ID == locationDetailsViewModel.ID);
                
                
            //then, assign allofthe properties of the viewmodel to the location object??
            locationDetailsViewModel.Name = location.Name;
            locationDetailsViewModel.Description = location.Description;
            locationDetailsViewModel.ID = location.ID;

            //then, to get the list of ratings and reviews that I need to display on the Details view
            //I have to create an instance of a LocationRating object
            //then, I have to check that/get the viewmodel id that was passed in from location index
            //matches the locationID in the Location Rating class and connect them.
            //find it through query
            // Models.LocationRating locationRating = context.LocationRatings
            //.Single(r => r.LocationID == locationDetailsViewModel.ID);


            //so I have made an instance of this, and because this is a foreign id, I can get all of the
            //properties associated with this specific Location Rating object

            List<Models.LocationRating> locationRatings = context.LocationRatings
                .Where(r => r.LocationID == locationDetailsViewModel.ID)
                .Include(r => r.Rating)
                .ToList();

            locationDetailsViewModel.LocationRatings = locationRatings;

            return locationDetailsViewModel;
            //List<Models.LocationRating> locationRatings = new List<Models.LocationRating>();


            //we need to find all of the Rating that are associated with the Location that had that ID and make
            //them into a list
            //we also need to find all of the Review that are associated with the Location that had that ID and make
            //them into a list
            //so, we can just display these two lists in the view model
            //can we do that?
            //I made lists of Ratings and Reviews as properties in the view model
            //then, I need to change these Location and Location Rating objects to ViewModel objects
            //so that they can be used in the view?

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
