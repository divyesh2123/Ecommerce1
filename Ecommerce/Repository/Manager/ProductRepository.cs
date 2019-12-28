using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Manager
{
    public class ProductRepository :  IProductRepository
    {
        private EcommerceDbContext Context { get; set; }

        public ProductRepository(EcommerceDbContext context)
        {
            Context = context;
        }
        public bool AddProduct(Product product)
        {
            bool result = false;

            Context.Product.Add(product);

            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }

        public Product GetProduct(int id)
        {
            return Context.Product.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<Product> GetProductInformation()
        {
            return Context.Product.ToList();
        }

        public bool RemoveProduct(int Id)
        {
            bool result = false;
            var dataProduct = Context.Product.Where(x => x.Id == Id).FirstOrDefault();
            Context.Remove(dataProduct);
            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }

        public bool UpdateProduct(Product product)
        {
            bool result = false;
            this.Context.Product.Attach(product);
            this.Context.Entry(product).State = EntityState.Modified;
            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }
    }
}
