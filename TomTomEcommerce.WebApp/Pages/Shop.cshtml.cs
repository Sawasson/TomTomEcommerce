using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.WebApp.Pages
{
    public class ShopModel : PageModel
    {
        private readonly TTWebServiceEFCore tTWebServiceEFCore;
        private readonly TTServiceEFCore tTServiceEFCore;


        public ShopModel(TTContext tTContext)
        {
            this.tTWebServiceEFCore = new TTWebServiceEFCore(tTContext);
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public List<TomTomEcommerce.Core.Category> CategoryList { get; set; }
        public List<TomTomEcommerce.Core.Product> ProductList { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public ProductImage ProductImage { get; set; }



        public void OnGet(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                ProductList = tTWebServiceEFCore.GetProductsByCategoryId(categoryId.Value);
                CategoryList = tTWebServiceEFCore.ListCategory();
                ProductImages = tTServiceEFCore.ListProductImage();
            }
            else
            {
                ProductList = tTWebServiceEFCore.ListProduct();
                CategoryList = tTWebServiceEFCore.ListCategory();
                ProductImages = tTServiceEFCore.ListProductImage();
            }
        }
    }
}
