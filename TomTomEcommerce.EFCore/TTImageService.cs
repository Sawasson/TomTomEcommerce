using System;
using System.Collections.Generic;
using System.Text;
using LazZiya.ImageResize;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace TomTomEcommerce.EFCore
{
    public class TTImageService
    {
        private TTContext dbContext { get; set; }

        public TTImageService(TTContext tTContext)
        {
            this.dbContext = tTContext;
        }

        //public void ScaleImages(List<IFormFile> Images, string webRootPath)
        //{
        //    foreach (var file in Images)
        //    {
                
        //        var filePath = Path.Combine(webRootPath, "img");
        //        var fullFilePath = Path.Combine(filePath, file.FileName);
        //        using (var filestream = new FileStream(fullFilePath, FileMode.Create))
        //        {
        //            //file.CopyTo(filestream);
        //            var img = Image.FromStream(filestream);
        //            var smallscale = ImageResize.Scale(img, 100, 100);
        //            var smallscalepath = "'" + filePath + "\\" + "small" + "s-" + file.FileName + "'";
        //            var mediumscale = ImageResize.Scale(img, 200, 200);
        //            var mediumscalepath = "'" + filePath + "\\" + "medium" + "m-" + file.FileName + "'";
        //            var largescale = ImageResize.Scale(img, 800, 800);
        //            var largescalepath = "'" + filePath + "\\" + "large" + "l-" + file.FileName + "'";

        //            smallscale.SaveAs(smallscalepath);
        //            mediumscale.SaveAs(mediumscalepath);
        //            largescale.SaveAs(largescalepath);
        //        }
        //        //tTServiceEFCore.AddProductImageById(file.FileName, id);

        //    }
        //}


    }
}
