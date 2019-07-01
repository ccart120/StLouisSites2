using Microsoft.EntityFrameworkCore;
using StLouisSites2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Location
{
    public class LocationEditViewModel
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
        public List<int>CategoryIDs { get; set; }
        public List<Models.Category>Categories { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel (int id, ApplicationDbContext context)
        {
            //gets the location object from context by id
            Models.Location location = context.Locations
                .Include(l => l.CategoryLocations)
                .Single(l => l.ID == id);
           
            //returns a populated LocationEditViewModel object
            

            Name = location.Name;
            Description = location.Description;
            Address = location.Address;
            County = location.County;
            CategoryIDs = location.CategoryLocations.Select(cl => cl.CategoryID).ToList();
            Categories = context.Categories.ToList();
        }
            
        //creates an instance of populated Location object and updates database with changes
        public void Persist(int id, ApplicationDbContext context)
        {
            Models.Location location = new Models.Location()
            {
                ID = id,
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                County = this.County
            };
            context.Update(location);
            List<Models.CategoryLocation> categoryLocations = CreateCategoryLocationRelationships(location.ID);
            location.CategoryLocations = categoryLocations;
            context.SaveChanges();

        }
        private List<Models.CategoryLocation> CreateCategoryLocationRelationships (int locationID)
        {
            return CategoryIDs.Select(catID => new Models.CategoryLocation { LocationID = locationID, CategoryID = catID })
                .ToList();
        }
        
    }
}
