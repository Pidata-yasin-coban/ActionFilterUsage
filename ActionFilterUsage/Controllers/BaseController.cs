using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionFilterUsage.Controllers
{
   
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
