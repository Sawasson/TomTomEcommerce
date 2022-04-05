using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.WebApp.Pages
{
    public class CartModel : PageModel
    {

        private readonly TTWebServiceEFCore tTWebServiceEFCore;
        private readonly TTServiceEFCore tTServiceEFCore;


        public CartModel(TTContext tTContext)
        {
            this.tTWebServiceEFCore = new TTWebServiceEFCore(tTContext);
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public Cart Cart { get; set; }
        public CartProduct CartProduct { get; set; }
        public int MyProperty { get; set; }
        public List<CartProduct> CartProducts { get; set; }


        public PageResult OnGet()
        {
            //var claims = HttpContext.User.Claims;
            //var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            //CartProducts = tTWebServiceEFCore.CartProductListByCartId(userId);

            return Page();
             
        }

        public PartialViewResult OnGetCartProductList()
        {
            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            CartProducts = tTWebServiceEFCore.CartProductListByCartId(userId);

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };

        }



        public void OnPostAddToCart(int productId)
        {
            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            tTWebServiceEFCore.AddProductToCart(productId, userId);
        }

        public PartialViewResult OnGetPlusCartProduct(int id)
        {
            tTWebServiceEFCore.PlusCartProduct(id);

            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            CartProducts = tTWebServiceEFCore.CartProductListByCartId(userId);

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }

        public PartialViewResult OnGetMinusCartProduct(int id)
        {
            tTWebServiceEFCore.MinusCartProduct(id);

            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            CartProducts = tTWebServiceEFCore.CartProductListByCartId(userId);

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }

        public PartialViewResult OnPostClearCart()
        {
            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            tTWebServiceEFCore.ClearCart(userId);

            
            CartProducts = tTWebServiceEFCore.CartProductListByCartId(userId);

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }


    }
}
