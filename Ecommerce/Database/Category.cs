using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Database
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        [Key]
        public  int Id { get; set; }

        public  string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
