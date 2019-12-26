using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDuLich.Models;
using Microsoft.AspNetCore.Http;
<<<<<<< HEAD
using WebDuLich.Extensions;
=======

>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25
namespace WebDuLich.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
<<<<<<< HEAD
         
=======
             string t=HttpContext.Session.GetString("hoten");
            if (t!=null)
            {
                t = "chung ta khong thuoc ve nhau";
            }
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
