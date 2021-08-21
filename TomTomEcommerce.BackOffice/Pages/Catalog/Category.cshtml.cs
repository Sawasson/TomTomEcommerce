using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.BackOffice.Pages.Catalog
{
    public class CategoryModel : PageModel
    {
        private readonly TTServiceEFCore tTServiceEFCore;

        public CategoryModel(TTContext tTContext)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public List<TomTomEcommerce.Core.Category> listmodel { get; set; }


        public PartialViewResult OnGetListCategory()
        {
            listmodel = tTServiceEFCore.ListCategory();

            return new PartialViewResult
            {
                ViewName = ("Category/_ListCategories"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Category>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetAddCategory()
        {

            return new PartialViewResult
            {
                ViewName = "Category/_AddCategoryForm",
            };
        }

        public PartialViewResult OnPostAddCategory(TomTomEcommerce.Core.Category category)
        {
            tTServiceEFCore.AddNewCategory(category);
            listmodel = tTServiceEFCore.ListCategory();

            return new PartialViewResult
            {
                ViewName = ("Category/_ListCategories"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Category>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetDeleteCategory(int id)
        {
            var item = tTServiceEFCore.FindCategory(id);
            return new PartialViewResult
            {
                ViewName = ("Category/_DeleteCategoryForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Category>(ViewData, item)
            };
        }

        public PartialViewResult OnPostDeleteCategory(int id)
        {
            tTServiceEFCore.DeleteCategory(id);
            listmodel = tTServiceEFCore.ListCategory();

            return new PartialViewResult
            {
                ViewName = ("Category/_ListCategories"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Category>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetEditCategory(int id)
        {
            var item = tTServiceEFCore.FindCategory(id);
            return new PartialViewResult
            {
                ViewName = ("Category/_EditCategoryForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Category>(ViewData, item)
            };
        }

        public PartialViewResult OnPostEditCategory(TomTomEcommerce.Core.Category category)
        {
            tTServiceEFCore.EditCategory(category);

            listmodel = tTServiceEFCore.ListCategory();

            return new PartialViewResult
            {
                ViewName = ("Category/_ListCategories"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Category>>(ViewData, listmodel)
            };
        }
    }
}
