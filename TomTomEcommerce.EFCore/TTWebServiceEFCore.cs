using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.EFCore
{
    public class TTWebServiceEFCore
    {
        private TTContext dbContext { get; set; }

        public TTWebServiceEFCore (TTContext tTContext)
        {
            this.dbContext = tTContext;
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            var entity = dbContext.Products.Where(x => x.CategoryId == id).ToList();
            return entity;
        }

        public List<Product> ListProduct()
        {
            var entity = dbContext.Products
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .ToList();
            return entity;
        }

        public List<Category> ListCategory()
        {
            var model = dbContext.Categories.ToList();
            return model;
        }

        public Product GetProduct(int id)
        {
            var model = dbContext.Products.Find(id);
            return model;
        }

        public Category GetCategory(int id)
        {
            var model = dbContext.Categories.Find(id);
            return model;
        }

    }
}
