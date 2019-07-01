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

        //public int ID { get; set; }
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

        public LocationCreateViewModel() { }

        //gets the category objects (put into a list) from context so we can use them in the view model
        public LocationCreateViewModel(ApplicationDbContext context)
        {
            this.Categories = context.Categories.ToList();
        }

        //this persists the location
        public void CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
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

            
        }
        //where does this locationID some from?
        //where does categoryId come from?
        //I think it's supposed to come from the CategoryLocation model, but we are setting it here, correct?
        //so shouldn't it be an is that gets passed in somehow? maybe that's location ID
        //but where does categoryID come from? wouldn't that be the same ID?
        private List<Models.CategoryLocation> CreateCategoryLocationRelationships(int locationID)
        {
            return CategoryIDs.Select(categoryID => new Models.CategoryLocation { LocationID = locationID, CategoryID = categoryID }).ToList();
        }



            
            
            
        }

    
    }



