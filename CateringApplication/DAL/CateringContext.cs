using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using CateringApplication.Models;

namespace CateringApplication.DAL
{
    public class CateringContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Town> Towns { get; set; }

        // table names will be called Food, Menu, Restaurant, Town
        // instaed of Foods, Menus, Restaurants, Towns
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}