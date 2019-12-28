using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;

namespace Ecommerce.Repository.Interface
{
   public interface IProductRepository
    {
        List<Product> GetProductInformation();

        bool AddProduct(Product productVieWModel);

        bool UpdateProduct(Product productVieWModel);

        bool RemoveProduct(int Id);

        Product GetProduct(int id);
    }
}
