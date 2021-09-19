using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;
using TomTomEcommerce.BackOffice;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TomTomEcommerce.WebApp.Pages
{
    public class OrderModel : PageModel
    {

        private readonly TTWebServiceEFCore tTWebServiceEFCore;
        private readonly TTServiceEFCore tTServiceEFCore;
        private readonly TTLocationService tTLocationService;


        public OrderModel(TTContext tTContext)
        {
            this.tTWebServiceEFCore = new TTWebServiceEFCore(tTContext);
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
            this.tTLocationService = new TTLocationService(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public Adress Adress { get; set; }
        public List<Adress> Adresses { get; set; }
        public SelectList Cities { get; set; }
        public SelectList Districts { get; set; }
        public Order Order { get; set; }



        public PageResult OnGet()
        {
            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var cities = tTLocationService.GetCities();
            Cities = new SelectList(cities, "Id", "Name");

            Adresses = tTWebServiceEFCore.ListAdresses(userId);

            return Page();


        }

        public PartialViewResult OnGetAdressPartial()
        {
            var cities = tTLocationService.GetCities();
            Cities = new SelectList(cities, "Id", "Name");
            //var districts = tTLocationService.GetDistrictsByCityId(cityId);
            //Cities = new SelectList(districts, "Id", "Name");



            return new PartialViewResult
            {
                ViewName = "_AdressForm",
                ViewData = new ViewDataDictionary<OrderModel>(ViewData, this)
            };
        }

        public RedirectToPageResult OnPostAddAdress(Adress adress)
        {
            var claims = HttpContext.User.Claims;
            var userId = Convert.ToInt32(claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            adress.UserId = userId;
            tTWebServiceEFCore.AddAdress(adress);
            return new RedirectToPageResult("Order");
        }

        public JsonResult OnPostGetDistricts(int CityId)
        {
            var districts = tTLocationService.GetDistrictsByCityId(CityId);
            return new JsonResult(districts);
        }


    }
}
