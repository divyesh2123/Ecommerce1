using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Database
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ApplicableDiscount { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }

        public  string UserId { get; set; }

        public Unit Unit { get; set; }
        public Category Category { get; set; }

        public  ApplicationUser ApplicationUser { get; set; }
    }
}
