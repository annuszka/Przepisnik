using Przepisnik.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Przepisnik.Data
{
    public class RecipesDBContext : DbContext
    {
        public RecipesDBContext() : base("RecipesDBContext")
        {
        }


        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //The modelBuilder.Conventions.Remove statement in the OnModelCreating 
            //method prevents table names from being pluralized.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    
    }
}