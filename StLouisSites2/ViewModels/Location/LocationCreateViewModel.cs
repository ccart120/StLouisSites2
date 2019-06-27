using StLouisSites2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Location
{
    public class LocationCreateViewModel
    {
        private ApplicationDbContext context;

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description must be between 3 and 200 characters.")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Description { get; set; }
        public string Address { get; set; }
        [Required]
        public string County { get; set; }

        public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        {
            Models.Location location = new Models.Location();
            {
                location.Name = locationViewModel.Name;
                location.Description = locationViewModel.Description;
                location.Address = locationViewModel.Address;
                location.County = locationViewModel.County;
            }
            context.Add(location);
            context.SaveChanges();

            return location.ID;
            
            
        }

    
    }


}
