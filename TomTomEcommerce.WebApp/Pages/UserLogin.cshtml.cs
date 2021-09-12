using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.WebApp.Pages
{
    public class UserLoginModel : PageModel
    {

        private readonly TTUserService tTUserService;


        public UserLoginModel(TTContext tTContext)
        {
            this.tTUserService = new TTUserService(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public User User { get; set; }



        public void OnGet()
        {
        }

        public async Task<RedirectToPageResult> OnPostLoginUser(User user)

        {
            bool login = tTUserService.LoginUser(user);
            if (login==true)
            {
                var userdata = tTUserService.GetUser(user.Email);

                var claims = new[] { new Claim(ClaimTypes.Name, userdata.Name),
                                     new Claim(ClaimTypes.Email, userdata.Email),
                                     new Claim(ClaimTypes.NameIdentifier, userdata.Id.ToString())};

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return new RedirectToPageResult("Shop");
            }
            else
            {
                return new RedirectToPageResult("Error");
            }
        }
    }
}
