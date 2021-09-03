using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.WebApp.Pages
{
    public class Product_DetailsModel : PageModel
    {
        private readonly TTWebServiceEFCore tTWebServiceEFCore;

        public Product_DetailsModel(TTContext tTContext)
        {
            this.tTWebServiceEFCore = new TTWebServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public TomTomEcommerce.Core.Product Product { get; set; }
        public TomTomEcommerce.Core.Category Category { get; set; }


        public void OnGet(int productId)
        {
            Product = tTWebServiceEFCore.GetProduct(productId);
            Product.Category = tTWebServiceEFCore.GetCategory(Product.CategoryId);
        }
    }
}
