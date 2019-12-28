using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        [MaxLength(100, ErrorMessage = "Product ")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ApplicableDiscount { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }

        public byte[] InternalImage { get; set; }

      
        [StringLength(1024)]
        public string ItemPictureUrl { get; set; }


    }
}
