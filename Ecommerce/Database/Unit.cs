using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Database
{
    public class Unit
    {
        [Key]
        public  int Id { get; set; }

        public  string UnitName { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
