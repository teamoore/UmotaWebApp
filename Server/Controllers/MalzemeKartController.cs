using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Controllers
{
    public class MalzemeKartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
