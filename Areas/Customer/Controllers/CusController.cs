using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDuLich.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CusController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}