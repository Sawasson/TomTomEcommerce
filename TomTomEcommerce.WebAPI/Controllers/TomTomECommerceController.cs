using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTomEcommerce.Core;
using TomTomEcommerce.EFCore;

namespace TomTomEcommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TomTomECommerceController : ControllerBase
    {
        private readonly TTServiceEFCore tTServiceEFCore;

        public TomTomECommerceController(TTContext tTContext)
        {
            this.tTServiceEFCore = new TTServiceEFCore(tTContext);
        }


    }
}
