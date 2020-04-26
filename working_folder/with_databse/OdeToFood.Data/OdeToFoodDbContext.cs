using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    // implement the db Context
    public class OdeToFoodDbContext:DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options):base(options)
        {
        }

        // add Dbset type with Resturant properties classs
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
