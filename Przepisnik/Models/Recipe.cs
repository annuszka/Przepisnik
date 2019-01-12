using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Przepisnik.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        [Required]
        [Display(Name ="Tytuł")]
        [StringLength(150, ErrorMessage = "Tytuł nie może być dłuższy niż 150 znaków")]
        public string Title { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Zdjęcie przepisu")]
        public string RecipePhotoUrl { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddingDate { get; set; }
        [Display(Name = "Opis")]
        [StringLength(150, ErrorMessage = "Opis nie może być dłuższy niż 150 znaków")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Składniki")]
        [DataType(DataType.MultilineText)]
        [StringLength(300, ErrorMessage = "Składniki nie mogą być dłuższe niż 300 znaków")]
        public string Ingredients { get; set; }
        [Required]
        [Display(Name = "Przygotowanie")]
        [StringLength(500, ErrorMessage = "nie może być dłuższy niż 500 znaków")]
        public string Preparation { get; set; }
        [Display(Name = "Czas wykonania")]
        public string PrepTime { get; set; }
        [Display(Name = "Ilość porcji")]
        public int Portions { get; set; }
        [Display(Name = "Źródło")]
        public string Source { get; set; }
        [Display(Name = "Oznacz jako publiczny")]
        public bool IfPublic { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Średnia ocena")]
        public double AverageRating { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; }
    }
}