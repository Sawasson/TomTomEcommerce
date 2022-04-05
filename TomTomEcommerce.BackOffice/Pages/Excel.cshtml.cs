using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OfficeOpenXml;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.BackOffice.Pages
{
    [Authorize]
    public class ExcelModel : PageModel
    {

        private readonly TTServiceEFCore tTServiceEFCore;

        public ExcelModel(TTContext tTContext)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }

        [BindProperty(SupportsGet = true)]
        public IFormFile UploadedFile { get; set; }
        public List<Brand> Brands { get; set; }



        public void OnGet()
        {
        }

        public IActionResult OnGetGiveBrandExcelTable()
        {
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Brands");


                worksheet.Cells["A1"].Value = "Brand Name";
                worksheet.DefaultColWidth = 20;

                worksheet.Cells["B1"].Value = "Description";

                worksheet.Column(2).Width = 100;


                xlPackage.Workbook.Properties.Title = ("Brand List");
                xlPackage.Workbook.Properties.Author = ("Savas Cagli");

                xlPackage.Save();
            }

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BrandList.xlsx");

        }

        public PageResult OnPostSaveBrandExcelTable(IFormFile exceltable)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            exceltable = UploadedFile;
            if (ModelState.IsValid)
            {
                if (exceltable?.Length>0)
                {
                    var stream = exceltable.OpenReadStream();

                    try
                    {
                        using (var package = new ExcelPackage(stream))
                        {
                            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                            int rowCount = workSheet.Dimension.Rows;
                            List<Brand> brandList = new List<Brand>();
                            for (int row = 2;  row <= rowCount; row++)
                            {
                                try
                                {
                                    var brandName = workSheet.Cells[row, 1].Value?.ToString();
                                    var description = workSheet.Cells[row, 2].Value?.ToString();

                                    Brand brand = new Brand()
                                    {

                                        Name = brandName,
                                        Description = description
                                    };

                                    brandList.Add(brand);
                                    
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                                Brands = brandList;
                            }
                            
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return Page();

        }

        public PageResult OnPostSaveDatabaseBrandExcelTable(List<Brand> list)
        {
            return Page();
        }
    }
}
