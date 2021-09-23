using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;
using LazZiya.ImageResize;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace TomTomEcommerce.BackOffice.Pages.Catalog
{
    [Authorize]
    public class ProductModel : PageModel
    {

        private readonly TTServiceEFCore tTServiceEFCore;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment;

        public ProductModel(TTContext tTContext, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
            this.hostingEnvironment = hostingEnvironment;
        }

        [BindProperty(SupportsGet = true)]
        public List<TomTomEcommerce.Core.Product> listmodel { get; set; }
        public TomTomEcommerce.Core.Product Product { get; set; }
        public TomTomEcommerce.Core.ProductImage ProductImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public SelectList Brands { get; set; }
        public SelectList Categories { get; set; }
        public List<IFormFile> UploadedFile { get; set; }


        public PartialViewResult OnGetListProduct()
        {
            listmodel = tTServiceEFCore.ListProduct();
            ProductImages = tTServiceEFCore.ListProductImage();

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProducts"),
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }


        public PartialViewResult OnGetListProductImage(int id)
        {
            ProductImages = tTServiceEFCore.ListProductImageById(id);

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProductImage"),
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }


        public PartialViewResult OnGetAddProduct()
        {
            var brands = tTServiceEFCore.GetBrands();
            var categories = tTServiceEFCore.GetCategories();

            Brands = new SelectList(brands, "Id", "Name");
            Categories = new SelectList(categories, "Id", "Name");

            //return new PartialViewResult
            //{
            //    ViewName = ("Product/_AddProductForm"),
            //    ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            //};
            return PartialView("Product/_AddProductForm", this);
        }

        public PartialViewResult OnPostAddProduct(TomTomEcommerce.Core.Product product)
        {

            tTServiceEFCore.AddNewProduct(product);


            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProducts"),
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }

        public PartialViewResult OnPostAddProductImage(int id)
        {
            //Image Upload
            foreach (var file in UploadedFile)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var fullFilePath = Path.Combine(filePath, newImageName);
                using (var filestream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                var img1 = Image.FromFile(fullFilePath);
                var smallscale1 = ImageResize.Scale(img1, 100, 100);
                var smallscalepath1 = filePath + "\\" + "small" + "\\" + "s-" + newImageName;
                //var mediumscale = ImageResize.Scale(img, 200, 200);
                //var mediumscalepath = filePath + "\\" + "medium" + "\\" + "m-" + newImageName;
                //var largescale = ImageResize.Scale(img, 800, 800);
                //var largescalepath = filePath + "\\" + "large" + "\\" + "l-" + newImageName;

                smallscale1.SaveAs(smallscalepath1);
                //mediumscale.SaveAs(mediumscalepath);
                //largescale.SaveAs(largescalepath);

                var filePathForWebApp = "C:\\Projects\\TomTomEcommerce\\TomTomEcommerce.WebApp\\wwwroot\\img\\product-img";
                var fullFilePathForWebApp = Path.Combine(filePathForWebApp, newImageName);
                using (var filestreamForWebApp = new FileStream(fullFilePathForWebApp, FileMode.Create))
                {
                    file.CopyTo(filestreamForWebApp);
                }

                var img = Image.FromFile(fullFilePath);
                var smallscale = ImageResize.Scale(img, 100, 100);
                var smallscalepath = filePathForWebApp + "\\" + "small" + "\\" + "s-" + newImageName;
                var mediumscale = ImageResize.Scale(img, 200, 200);
                var mediumscalepath = filePathForWebApp + "\\" + "medium" + "\\" + "m-" + newImageName;
                var largescale = ImageResize.Scale(img, 800, 800);
                var largescalepath = filePathForWebApp + "\\" + "large" + "\\" + "l-" + newImageName;

                smallscale.SaveAs(smallscalepath);
                mediumscale.SaveAs(mediumscalepath);
                largescale.SaveAs(largescalepath);


                tTServiceEFCore.AddProductImageById(newImageName, id);

            }


            Product = tTServiceEFCore.FindProduct(id);
            ProductImages = tTServiceEFCore.ListProductImageById(id);

            return new PartialViewResult
            {
                ViewName = "Product/_ListProductImage",
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }

        public PartialViewResult OnGetDeleteProductImage(int id)
        {
            ProductImage = tTServiceEFCore.FindProductImageById(id);

            return new PartialViewResult
            {
                ViewName = "Product/_DeleteProductImageForm",
                ViewData = new ViewDataDictionary<ProductImage>(ViewData, ProductImage)
            };
        }

        public PartialViewResult OnPostDeleteProductImage(int id)
        {
            var model = tTServiceEFCore.FindProductImageById(id);
            tTServiceEFCore.DeleteProductImageById(id);

            ProductImages = tTServiceEFCore.ListProductImageById(model.ProductId);

            return new PartialViewResult
            {
                ViewName = "Product/_ListProductImage",
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }


        public PartialViewResult OnGetDeleteProduct(int id)
        {
            var item = tTServiceEFCore.FindProduct(id);
            var brand = tTServiceEFCore.FindBrand(item.BrandId);
            item.Brand = brand;
            var category = tTServiceEFCore.FindCategory(item.CategoryId);
            item.Category = category;
            return new PartialViewResult
            {
                ViewName = ("Product/_DeleteProductForm"),
                ViewData = new ViewDataDictionary<TomTomEcommerce.Core.Product>(ViewData, item)
            };
        }

        public PartialViewResult OnPostDeleteProduct(int id)
        {
            tTServiceEFCore.DeleteProduct(id);

            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = ("Product/_ListProducts"),
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }

        public PartialViewResult OnGetEditProduct(int id)
        {
            var item = tTServiceEFCore.FindProduct(id);
            Product = item;
            var brands = tTServiceEFCore.GetBrands();
            var categories = tTServiceEFCore.GetCategories();

            Brands = new SelectList(brands, "Id", "Name");
            Categories = new SelectList(categories, "Id", "Name");


            ProductImages = tTServiceEFCore.ListProductImageById(id);

            return new PartialViewResult
            {
                ViewName = ("Product/_EditProductForm"),
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }

        public PartialViewResult OnPostEditProduct(TomTomEcommerce.Core.Product product)
        {
            tTServiceEFCore.EditProduct(product);

            listmodel = tTServiceEFCore.ListProduct();

            return new PartialViewResult
            {
                ViewName = "Product/_ListProducts",
                ViewData = new ViewDataDictionary<ProductModel>(ViewData, this)
            };
        }

        public PartialViewResult PartialView<T>(string partialname,T Model)
        {
            return new PartialViewResult
            {
                ViewName = partialname,
                ViewData = new ViewDataDictionary<T>(ViewData, Model)
            };

        }
    }
}
