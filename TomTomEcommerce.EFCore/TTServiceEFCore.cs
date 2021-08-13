using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
