using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przepisnik.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        public int UserID { get; set; }
        public int RecipeID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime CommentDate { get; set; }

        [Display(Name ="Treść komentarza"), StringLength(350, ErrorMessage ="Komentarz jest zbyt długi.")]
        public string Content{ get; set; }

        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}