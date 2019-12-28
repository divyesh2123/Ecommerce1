using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Servicies.Interface
{
    public interface ICategoryService
    {
         List<CategoryVieWModel> GetCategoryInformation();

        CategoryVieWModel GetCategoryInformation(int id);

         bool AddCategory(CategoryVieWModel categoryVieWModel);

         bool UpdateCategory(CategoryVieWModel categoryVieWModel);

        bool RemoveCategory(int Id);
    }
}
