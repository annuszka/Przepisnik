using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przepisnik.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        
        [Display(Name = "Login"), StringLength(30, MinimumLength = 1)]
        public string Login { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Hasło"), StringLength(30, MinimumLength = 8, ErrorMessage ="Hasło musi mieć co najmniej 8 znaków")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage ="Wprowadź prawidłowy adres email.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), StringLength(40)]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public string AvatarImg { get; set; }

        [Display(Name = "Imię"), StringLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko"), StringLength(40)]
        public string LastName { get; set; }

        [Range(0,1)]
        public int AccessRigths { get; set; }
        
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}