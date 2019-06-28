using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<CategoryLocation> CategoryLocations { get; set; } 
    }
}
