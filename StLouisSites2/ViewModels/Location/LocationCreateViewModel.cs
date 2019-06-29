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

        [Display(Name = "Select One or More Categories")]
        public List<int> CategoryIDs { get; set; }
        public List<Models.Category> Categories { get; set; }

        public LocationCreateViewModel(ApplicationDbContext context)
        {
            this.Categories = context.Categories.ToList();
        }

        public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        {
            Models.Location location = new Models.Location();
            {
                location.Name = locationViewModel.Name;
                location.Description = locationViewModel.Description;
                location.Address = locationViewModel.Address;
                location.County = locationViewModel.County;
            }
            //have to specify becaue there are multiple lists in DbContext
            context.Locations.Add(location);
            List<Models.CategoryLocation> categoryLocations = CreateCategoryLocationRelationships(location.ID);
            //this refers to the list stored in the Location model
            location.CategoryLocations = categoryLocations;
            context.SaveChanges();

            return location.ID;
        }
        //where does this locationID some from?
        //where does catId come from?
        private List<Models.CategoryLocation> CreateCategoryLocationRelationships(int locationID)
        {
            return CategoryIDs.Select(catId => new Models.CategoryLocation { LocationID = locationID, CategoryID = catID }).ToList();
        }



            
            
            
        }

    
    }



