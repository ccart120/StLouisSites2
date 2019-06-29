using StLouisSites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites2.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        private ApplicationDbContext context;

        public int ID { get; set; }

        public string Name { get; set; }

        public static int CreateCategory(ApplicationDbContext context, CategoryCreateViewModel categoryCreateViewModel )
        {
            Models.Category category = new Models.Category();
            {
                category.Name = categoryCreateViewModel.Name;
            }
            context.Add(category);
            context.SaveChanges();

            return category.ID;
        }
    }
}
