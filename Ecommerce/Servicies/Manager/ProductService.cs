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
    public class ProductService : IProductService
    {
        private IProductRepository ProductRepository { get; set; }

        private IMapper Mapper { get; set; }

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            ProductRepository = productRepository;
            Mapper = mapper;
        }

        public bool AddProduct(ProductViewModel productVieWModel)
        {
            var model = Mapper.Map<Product>(productVieWModel);
            return ProductRepository.AddProduct(model);
        }

        public List<ProductViewModel> GetProductInformation()
        {
            var productResult = ProductRepository.GetProductInformation();
            var model = Mapper.Map<List<ProductViewModel>>(productResult);
            return model;
        }

        public bool RemoveProduct(int Id)
        {
            return ProductRepository.RemoveProduct(Id);
        }

        public bool UpdateProduct(ProductViewModel categoryVieWModel)
        {
            var model = Mapper.Map<Product>(categoryVieWModel);
            return ProductRepository.UpdateProduct(model);
        }

        public ProductViewModel GetProductInformation(int id)
        {
            var model = ProductRepository.GetProduct(id);

            var result = Mapper.Map<ProductViewModel>(model);

            return result;

        }
      
    }
}
