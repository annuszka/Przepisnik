using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przepisnik.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string RecipePhotoUrl { get; set; }
        public DateTime AddingDate { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string PrepTime { get; set; }
        public int Portions { get; set; }
        public string Source { get; set; }
        public bool IfPublic { get; set; }
        public int UserId { get; set; }
        public int AverageRating { get; set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }
    }
}