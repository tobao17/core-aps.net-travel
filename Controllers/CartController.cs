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
<<<<<<< HEAD
            string id_text = HttpContext.Session.GetString("khachhangid");
            if (id_text==null || id_text=="")
            {
                return RedirectToAction("Index", "Login");
            }
=======
            List<DatTour> datTours = _db.DatTours.ToList();
            List<ChiTietDatTour> chiTietDatTours = _db.ChiTietDatTours.ToList();
            List<Tour> tours = _db.Tours.ToList();
            List<TuyenDuong> tuyenDuongs = _db.TuyenDuongs.ToList();
            var result = from dt in datTours
                         join ct in chiTietDatTours on dt.MaDat equals ct.MaTour into table1
                         from ct in table1.ToList()
                         join t in tours on ct.MaTour equals t.MaTour into table2
                         from t in table2.ToList()
                         join td in tuyenDuongs on t.MaTuyenDuong equals td.MaTuyenDuong into table3
                         from td in table3.ToList()
                         select new ViewModel
                         {
                             datTour = dt,
                             chiTietDatTour = ct,
                             Tour = t,
                             tuyenDuong = td

                         };
            return View(_db.ChiTietDatTours.ToList());

            //var result2 = from person in result
            //              join detail in tours on person.matour equals detail.MaTour
            //              select new 
            //              {
            //                  idCTDT = person.idCTDT,
            //                  sdt = person.sdt,
            //                  MaTour = detail.MaTour,
            //                  songuoiditour = person.songuoiditour,
            //                  MaKH = person.MaKH,
            //                  matuyenduong = detail.MaTuyenDuong
            //              };
            //var result3 = from person in result2
            //              join detail in tuyenDuongs on person.matuyenduong equals detail.MaTuyenDuong
            //              select new ViewModel
            //              {
            //                  id = person.idCTDT,
            //                  sdt = person.sdt,
            //                  matour = person.MaTour,
            //                  songuoiditour = person.songuoiditour,
            //                  MaKH = person.MaKH,
            //                  tentuyenduong = detail.TenTuyenDuong,
            //                  image = detail.Anh
            //              };



>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25

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