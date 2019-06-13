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
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public static int CreateLocationRating(ApplicationDbContext context, LocationRatingCreateViewModel viewModelRating)
        {
            Models.LocationRating locationRating = new Models.LocationRating();

            locationRating.Rating = viewModelRating.Rating;
            locationRating.Review = viewModelRating.Review;

            context.Add(locationRating);
            context.SaveChanges();
            return locationRating.ID;
        }
    }

    
}
