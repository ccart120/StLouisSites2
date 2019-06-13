﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StLouisSites2.Models;

namespace StLouisSites2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationRating> LocationRatings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
