using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przepisnik.Models
{
    public class RecipeCategory
    {
        public int ID { get; set;}
        public int RecipeID { get; set; }
        public int CategoryID { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Category Category { get; set; }
    }
}