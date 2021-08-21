using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.BackOffice.Pages.Catalog
{
    public class ProductModel : PageModel
    {

        private readonly TTServiceEFCore tTServiceEFCore;

        public ProductModel(TTContext tTContext)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public List<TomTomEcommerce.Core.Product> listmodel { get; set; }
        public TomTomEcommerce.Core.Product Product { get; set; }
        public SelectList Brands { get; set; }
        public SelectList Categories { get; set; }


        public PartialViewResult OnGetListProduct()
        {
            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProducts"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Product>>(ViewData, listmodel)
            };
        }

        //private void PopulateCategories()
        //{
        //    var categories = tTServiceEFCore.GetCategories();
        //    Categories = new SelectList(categories, "Id", "Name");
        //}

        //private void PopulateBrands()
        //{
        //    var brands = tTServiceEFCore.GetBrands();
        //    Brands = new SelectList(brands, "Id", "Name");
        //}

        public PartialViewResult OnGetAddProduct()
        {
            var brands = tTServiceEFCore.GetBrands();
            var categories = tTServiceEFCore.GetCategories();

            Brands = new SelectList(brands, "Id", "Name");
            Categories = new SelectList(categories, "Id", "Name");

            return PartialView("Product/_AddProduct", this);
        }

        public PartialViewResult OnPostAddProduct(TomTomEcommerce.Core.Product product)
        {
            tTServiceEFCore.AddNewProduct(product);
            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProduct"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Product>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetDeleteProduct(int id)
        {
            var item = tTServiceEFCore.FindProduct(id);
            return new PartialViewResult
            {
                ViewName = ("Product/_DeleteProductForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Product>(ViewData, item)
            };
        }

        public PartialViewResult OnPostDeleteProduct(int id)
        {
            tTServiceEFCore.DeleteProduct(id);
            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProducts"),
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Product>>(ViewData, listmodel)
            };
        }

        public PartialViewResult OnGetEditProduct(int id)
        {
            var item = tTServiceEFCore.FindProduct(id);
            return new PartialViewResult
            {
                ViewName = ("Product/_EditProductForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Product>(ViewData, item)
            };
        }

        public PartialViewResult OnPostEditProduct(TomTomEcommerce.Core.Product product)
        {
            tTServiceEFCore.EditProduct(product);

            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = "Product/_ListProducts",
                ViewData = new ViewDataDictionary<List<TomTomEcommerce.Core.Product>>(ViewData, listmodel)
            };
        }

        public PartialViewResult PartialView<T>(string partialname,T Model)
        {
            return new PartialViewResult
            {
                ViewName = partialname,
                ViewData = new ViewDataDictionary<T>(ViewData, Model)
            };

        }
    }
}