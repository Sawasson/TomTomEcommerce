using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.BackOffice.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TTServiceEFCore tTServiceEFCore;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment;

        public IndexModel(TTContext tTContext)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public List<TomTomEcommerce.Core.Category> CategortList { get; set; }
        public List<TomTomEcommerce.Core.Brand> BrandList { get; set; }
        public List<TomTomEcommerce.Core.Product> ProductList { get; set; }
        public TomTomEcommerce.Core.ProductImage ProductImage { get; set; }


        public void OnGet()
        {
            CategortList = tTServiceEFCore.ListCategory();
            BrandList = tTServiceEFCore.ListBrand();
            ProductList = tTServiceEFCore.ListProduct();
        }

        //public PageResult 
    }
}
