using System.Collections.Generic;
using System.Linq;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.EFCore
{
    public class TTServiceEFCore
    {
        private TTContext dbContext { get; set; }

        public TTServiceEFCore(TTContext tTContext)
        {
            this.dbContext = tTContext;
        }

        public Category FindCategory(int id)
        {
            var model = dbContext.Categories.Find(id);
            return model;
        }

        public List<Category> ListCategory()
        {
            var model = dbContext.Categories.ToList();
            return model;
        }

        public void AddNewCategory(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var entity = FindCategory(id);
            dbContext.Set<Category>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            var entity = dbContext.Categories.Find(category.Id);
            entity.Id = category.Id;
            entity.Name = category.Name;
            entity.Description = category.Description;
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        public Brand FindBrand(int id)
        {
            var model = dbContext.Brands.Find(id);
            return model;
        }

        public List<Brand> ListBrand()
        {
            var model = dbContext.Brands.ToList();
            return model;
        }

        public void AddNewBrand(Brand brand)
        {
            dbContext.Brands.Add(brand);
            dbContext.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var entity = FindBrand(id);
            dbContext.Set<Brand>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void EditBrand(Brand brand)
        {
            var entity = dbContext.Brands.Find(brand.Id);
            entity.Id = brand.Id;
            entity.Name = brand.Name;
            entity.Description = brand.Description;
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
