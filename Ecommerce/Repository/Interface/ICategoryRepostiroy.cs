using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.ViewModels;

namespace Ecommerce.Repository.Interface
{
  public  interface ICategoryRepostiroy
    {
        List<Category> GetCategoryInformation();

        bool AddCategory(Category categoryVieWModel);

        bool UpdateCategory(Category categoryVieWModel);

        bool RemoveCategory(int Id);

        Category GetCategory(int id);
    }
}
