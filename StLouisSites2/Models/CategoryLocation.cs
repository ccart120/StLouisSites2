using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.Models
{
    public class CategoryLocation
    {
        public int ID { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set;}

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


    }
}
