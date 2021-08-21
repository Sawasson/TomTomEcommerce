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
    public class BrandModel : PageModel
    {
        private readonly TTServiceEFCore tTServiceEFCore;

        public BrandModel(TTContext tTContext)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public List<TomTomEcommerce.Core.Brand> listmodel { get; set; }

        public PartialViewResult OnGetListBrand()
        {
            listmodel = tTServiceEFCore.ListBrand();

            return new PartialViewResult
            {
                ViewName = ("Brand/_ListBrands"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Brand>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetAddBrand()
        {

            return new PartialViewResult
            {
                ViewName = "Brand/_AddBrandForm",
            };
        }

        public PartialViewResult OnPostAddBrand(TomTomEcommerce.Core.Brand brand)
        {
            tTServiceEFCore.AddNewBrand(brand);
            listmodel = tTServiceEFCore.ListBrand();

            return new PartialViewResult
            {
                ViewName = ("Brand/_ListBrands"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Brand>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetDeleteBrand(int id)
        {
            var item = tTServiceEFCore.FindBrand(id);
            return new PartialViewResult
            {
                ViewName = ("Brand/_DeleteBrandForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Brand>(ViewData, item)
            };
        }

        public PartialViewResult OnPostDeleteBrand(int id)
        {
            tTServiceEFCore.DeleteBrand(id);
            listmodel = tTServiceEFCore.ListBrand();

            return new PartialViewResult
            {
                ViewName = ("Brand/_ListBrands"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Brand>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetEditBrand(int id)
        {
            var item = tTServiceEFCore.FindBrand(id);
            return new PartialViewResult
            {
                ViewName = ("Brand/_EditBrandForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Brand>(ViewData, item)
            };
        }

        public PartialViewResult OnPostEditBrand(TomTomEcommerce.Core.Brand brand)
        {
            tTServiceEFCore.EditBrand(brand);

            listmodel = tTServiceEFCore.ListBrand();

            return new PartialViewResult
            {
                ViewName = ("Brand/_ListBrands"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Brand>>(ViewData, listmodel)
            };
        }

    }
}

