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





    }
}
