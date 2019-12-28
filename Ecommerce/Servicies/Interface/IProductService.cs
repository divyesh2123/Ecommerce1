using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.ViewModels;

namespace Ecommerce.Servicies.Interface
{
    public interface IProductService
    {
        List<ProductViewModel> GetProductInformation();

        ProductViewModel GetProductInformation(int id);

        bool AddProduct(ProductViewModel ProductVieWModel);

        bool UpdateProduct(ProductViewModel ProductVieWModel);

        bool RemoveProduct(int Id);
    }
}
