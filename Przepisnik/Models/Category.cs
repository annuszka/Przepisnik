using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przepisnik.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }
        [Display(Name = "Kategoria"), StringLength(50)]
        public string CategoryName { get; set; }


        public virtual ICollection<Recipe> Recipes { get; set; } 
    }
}