using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;

namespace Ecommerce.Servicies.Manager
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepostiroy  CategoryRepository { get; set; }

        private  IMapper Mapper { get; set; }

        public CategoryService(ICategoryRepostiroy categoryRepostiroy, IMapper mapper)
        {
            CategoryRepository = categoryRepostiroy;

            Mapper = mapper;
        }

        public bool AddCategory(CategoryVieWModel categoryVieWModel)
        {
            var model = Mapper.Map<Category>(categoryVieWModel);
            return CategoryRepository.AddCategory(model);
        }

        public List<CategoryVieWModel> GetCategoryInformation()
        {
            var categoryResult = CategoryRepository.GetCategoryInformation();
            var model = Mapper.Map<List<CategoryVieWModel>>(categoryResult);
            return model;
        }

        public bool RemoveCategory(int Id)
        {
            return CategoryRepository.RemoveCategory(Id);
        }

        public bool UpdateCategory(CategoryVieWModel categoryVieWModel)
        {
            var model = Mapper.Map<Category>(categoryVieWModel);
            return CategoryRepository.UpdateCategory(model);
        }

        public CategoryVieWModel GetCategoryInformation(int id)
        {
            var model = CategoryRepository.GetCategory(id);

            var result = Mapper.Map<CategoryVieWModel>(model);

            return result;

        }

    }
}
