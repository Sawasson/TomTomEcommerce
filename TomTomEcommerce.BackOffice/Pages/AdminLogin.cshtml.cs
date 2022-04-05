using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.BackOffice.Pages
{
    public class AdminLoginModel : PageModel
    {

        private readonly TTUserService tTUserService;


        public AdminLoginModel(TTContext tTContext)
        {
            this.tTUserService = new TTUserService(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public User User { get; set; }
        public string Message { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAdmin(User user)

        {

            bool login = tTUserService.LoginAdmin(user);
            if (login == true)
            {
                var userdata = tTUserService.GetUser(user.Email);

                var claims = new List<Claim>
                { 
                    new Claim("Name", userdata.Name),
                    new Claim("Surname", userdata.LastName),
                    new Claim("Email", userdata.Email),
                    new Claim("NameIdentifier", userdata.Id.ToString())};

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return new RedirectToPageResult("Index");
            }
            else
            {
                ViewData["Message"] = "Email or Password No Match!";
            }
            return Page();
        }

        public async Task<RedirectToPageResult> OnPostLogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return new RedirectToPageResult("AdminLogin");
        }

        public void OnGetFalse()
        {

        }
    }
}
