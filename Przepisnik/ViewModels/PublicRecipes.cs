using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przepisnik.ViewModels
{
    public class PublicRecipes
    {
        public int PublicID { get; set; }
        public string PreparationT { get; set; }
        public string RecipeTitle { get; set; }
        public string Descr { get; set; }
        public string Image { get; set; }
    }
}