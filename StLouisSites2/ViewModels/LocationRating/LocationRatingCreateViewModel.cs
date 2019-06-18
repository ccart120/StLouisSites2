using StLouisSites2.Data;
using StLouisSites2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.LocationRating
{
    public class LocationRatingCreateViewModel
    {
        private ApplicationDbContext context;

        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public static LocationRatingCreateViewModel GetLocationRatingViewModel(ApplicationDbContext context, int locationID)
        {
            LocationRatingCreateViewModel locationRatingCreateViewModel = new LocationRatingCreateViewModel();
            Models.LocationRating locationRating = new Models.LocationRating();
            var viewModelLocation = context.Locations.Find(locationID);
            locationRatingCreateViewModel.LocationName = viewModelLocation.Name;
            locationRatingCreateViewModel.LocationID = locationID;
            return locationRatingCreateViewModel;
        }

        public void Persist(ApplicationDbContext context)
        {
            Models.LocationRating locationRating = new Models.LocationRating();
            {
                locationRating.Rating = this.Rating;
                locationRating.Review = this.Review;
                locationRating.ID = this.LocationID;
            }
            context.Add(locationRating);
            context.SaveChanges();
            //return locationRating.ID;
        }
        

        //public static int CreateLocationRating(ApplicationDbContext context, LocationRatingCreateViewModel locationRatingCreateViewModel)
        //    {
        //        Models.LocationRating locationRating = new Models.LocationRating();
        //        Models.Location location = new Models.Location();
        //        get location name from dbcontext location
        //            first get locationID(locationrating)
        //            viewModelRating.LocationName = Models.Location.Name;

        //        viewModelRating.LocationID = Models.Location.ID;
        //        locationRating.LocationID = viewModelRating.LocationID;

        //    context.Add(locationRating);
        //        context.SaveChanges();
        //        return locationRating.ID;
        //    }
        
    }

    
}
