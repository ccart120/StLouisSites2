using StLouisSites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Location
{
    public class LocationEditViewModel
    {
        private ApplicationDbContext context;
        public int ID { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Description must be between 2 and 200 characters.")]
        //[MinLength(2)]
        //[MaxLength(200)]
        public string Description { get; set; }
        public string Address { get; set; }
        //[Required]
        public string County { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel (int id, ApplicationDbContext context)
        {
            //gets the location object from context by id
            Models.Location location = context.Locations.
                Single(l => l.ID == id);
            //returns a populated LocationEditViewModel object
            //still need to create an instance??

            Name = location.Name;
            Description = location.Description;
            Address = location.Address;
            County = location.County;
            
        }
            
        
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
            context.SaveChanges();

        }
        
    }
}
