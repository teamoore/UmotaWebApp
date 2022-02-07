using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariController : ControllerBase
    {
        public ILogger<CariController> Logger { get; }

        public CariController(ILogger<CariController> logger)
        {
            Logger = logger;
        }

        [HttpGet("list")]
        public string MyCode()
        {
            return "Koray"; 
        }
    }
}
