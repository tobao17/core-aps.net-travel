using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDuLich.Data;
using WebDuLich.Models.DataModel;
using Microsoft.AspNetCore.Http;
using WebDuLich.Extensions;
using Microsoft.EntityFrameworkCore;

namespace WebDuLich.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task< IActionResult> Index()
        {
            string id_text = HttpContext.Session.GetString("khachhangid");
            if (id_text==null || id_text=="")
            {
                return RedirectToAction("Index", "Login");
            }

            var chitiet = _db.ChiTietDatTours.Include(m => m.DatTour).Include(m => m.Tour.TuyenDuong).Where(n=>n.DatTour.TinhTrang!="DaHuy");
 
            return View(await chitiet.ToListAsync());

           
        }
        public IActionResult delete(int id)
        {
            var datTour = _db.DatTours.SingleOrDefault(n=>n.MaDat==id);
            datTour.TinhTrang = "DaHuy";
            _db.SaveChanges();
            var chitiet = _db.ChiTietDatTours.Include(m => m.DatTour).Include(m => m.Tour.TuyenDuong).Where(n => n.DatTour.TinhTrang != "DaHuy");
            int a = int.Parse(HttpContext.Session.GetString("count_tour"));
            HttpContext.Session.SetString("count_tour", (a - 1).ToString());
            return RedirectToAction(nameof(Index),chitiet.ToListAsync());
        }
    }
}