using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;

namespace Ecommerce.Repository.Manager
{
    public class CategoryRepository : ICategoryRepostiroy
    {
        private EcommerceDbContext Context { get; set; }

        public CategoryRepository(EcommerceDbContext context)
        {
            Context = context;
        }
        public bool AddCategory(Category categoryVieWModel)
        {
            bool result = false;

            Context.Categoy.Add(categoryVieWModel);

                if (Context.SaveChanges() > 0)
                    result = true;
            

            return result;
        }

        public List<Category> GetCategoryInformation()
        {
            return Context.Categoy.ToList();
        }

        public bool RemoveCategory(int Id)
        {
            bool result = false;
            var dataCategory = Context.Categoy.Where(x => x.Id == Id).FirstOrDefault();
            Context.Remove(dataCategory);
            if (Context.SaveChanges() > 0)
                result = true;

            return result;

        }

        public bool UpdateCategory(Category categoryVieWModel)
        {
            bool result = false;
            this.Context.Categoy.Attach(categoryVieWModel);
            this.Context.Entry(categoryVieWModel).Property(p => p.Name).IsModified = true;

            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }

        public Category GetCategory(int id)
        {
            var dataCategory = Context.Categoy.Where(x => x.Id == id).FirstOrDefault();

            return dataCategory;
        }
    }
}
