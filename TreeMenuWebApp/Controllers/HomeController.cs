using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;
using TreeMenuWebApp.Models;

namespace TreeMenuWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TTServiceEFCore tTServiceEFCore;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment;

        public HomeController(TTContext tTContext, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = tTServiceEFCore.GetCategories();

            List<CategoryModelView> list = new List<CategoryModelView>();

            foreach (var item in categoryList)
            {
                list.Add(new CategoryModelView
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId
                });
            }

            var categoryModel = ToTree(list, null);
            return View(categoryModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public PartialViewResult CategoryTreeMenu()
        {
            return PartialView("_CategoryTreeMenu");
        }

        public IActionResult LoadCategory()
        {
            List<Category> categoryList = tTServiceEFCore.GetCategories();

            List<CategoryModelView> list = new List<CategoryModelView>();

            foreach (var item in categoryList)
            {
                list.Add(new CategoryModelView
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId
                });
            }
                
            var categoryModel = ToTree(list, null);
            return PartialView("_CategoryTreeMenu.cshtml", categoryModel);
        }

        public static List<CategoryModelView> ToTree(IEnumerable<CategoryModelView> list, List<CategoryModelView> parents = null)
        {
            if (parents == null)
            {
                parents = list.OrderBy(p => p.Name)
                    .Where(a => !a.ParentId.HasValue).ToList();
            }

            for (int i = 0; i < parents.Count; i++)
            {

                //if (parents[i].ParentId.HasValue)
                //{

                //    parents[i].Parent = list.Where(l => l.Id == parents[i].ParentId.Value).SingleOrDefault();
                //}

                var childs = list.OrderBy(x=>x.Name)
                            .Where(l => l.ParentId == parents[i].Id).ToList();

                if (childs != null)
                {
                    parents[i].Childs = new List<CategoryModelView>(childs);
                    ToTree(list, childs);
                }
            }
            return parents;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
