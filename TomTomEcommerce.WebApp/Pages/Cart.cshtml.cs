using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
            CartProducts = tTWebServiceEFCore.CartProductListByCartId();
            return Page();
             
        }

        public PartialViewResult OnGetCartProductList()
        {
            CartProducts = tTWebServiceEFCore.CartProductListByCartId();

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };

        }



        public PartialViewResult OnGetHeaderCartMenu()
        {
            Cart = tTWebServiceEFCore.GetCart();
            if (Cart != null)
            {
                //Product = tTServiceEFCore.FindProduct(Cart.ProductId);
                //ProductImages = tTServiceEFCore.ListProductImageById(Cart.ProductId);
            }
            

            return new PartialViewResult
            {
                ViewName = "_HeaderCartMenu",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }

        public void OnPostAddToCart(int productId)
        {
            tTWebServiceEFCore.AddProductToCart(productId);
        }

        public PartialViewResult OnGetPlusCartProduct(int id)
        {
            tTWebServiceEFCore.PlusCartProduct(id);

            CartProducts = tTWebServiceEFCore.CartProductListByCartId();

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }

        public PartialViewResult OnGetMinusCartProduct(int id)
        {
            tTWebServiceEFCore.MinusCartProduct(id);

            CartProducts = tTWebServiceEFCore.CartProductListByCartId();

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }

        public PartialViewResult OnPostClearCart()
        {
            tTWebServiceEFCore.ClearCart();

            CartProducts = tTWebServiceEFCore.CartProductListByCartId();

            return new PartialViewResult
            {
                ViewName = "_CartProductList",
                ViewData = new ViewDataDictionary<CartModel>(ViewData, this)
            };
        }


    }
}
