using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.WebApp.Pages
{
    public class OrderListModel : PageModel
    {

        private readonly TTWebServiceEFCore tTWebServiceEFCore;
        private readonly TTServiceEFCore tTServiceEFCore;
        private readonly TTLocationService tTLocationService;


        public OrderListModel(TTContext tTContext)
        {
            this.tTWebServiceEFCore = new TTWebServiceEFCore(tTContext);
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
            this.tTLocationService = new TTLocationService(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        //public Adress Adress { get; set; }
        //public List<Adress> Adresses { get; set; }
        //public SelectList Cities { get; set; }
        //public SelectList Districts { get; set; }
        //public Order Order { get; set; }
        public List<CartProduct> CartProducts { get; set; }
        public List<Order> Orders { get; set; }

        public void OnGet()
        {
            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Orders = tTWebServiceEFCore.OrderList(userId);


        }
    }
}
