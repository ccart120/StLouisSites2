﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string County { get; set; }

        public List<LocationRating> LocationRatings { get; set; }

        public List<CategoryLocation> CategoryLocations { get; set; } 

    }
}
