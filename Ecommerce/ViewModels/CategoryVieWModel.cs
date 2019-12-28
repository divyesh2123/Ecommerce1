using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class CategoryVieWModel
    {
        public  int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        [MaxLength(100,ErrorMessage = "Category ")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]

        [Display(Name = "Category Name")]
        public  string Name { get; set; }

        public  bool IsActive { get; set; }
    }
}
