using StLouisSites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Location
{
    public class LocationCreateViewModel
    {
        private ApplicationDbContext context;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        {
            Models.Location location = new Models.Location();
            
            location.Name = locationViewModel.Name;
            location.Description = locationViewModel.Description;
            context.Add(location);
            context.SaveChanges();

            return location.ID;
            
            
        }

    
    }


}
