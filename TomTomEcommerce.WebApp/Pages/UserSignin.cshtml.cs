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
    public class UserSigninModel : PageModel
    {

        private readonly TTUserService tTUserService;


        public UserSigninModel(TTContext tTContext)
        {
            this.tTUserService = new TTUserService(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public User User { get; set; }



        public void OnGet()
        {
        }

        public RedirectToPageResult OnPostCreateNewUser(User user)

        {
            tTUserService.CreateNewUser(user);
            return new RedirectToPageResult("Shop");

        }
    }
}
