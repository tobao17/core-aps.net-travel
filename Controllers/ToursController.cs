using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDuLich.Data;
using WebDuLich.Models.DataModel;
namespace WebDuLich.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ToursController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            return View(_db.TuyenDuongs.ToList());
        }
        public IActionResult detailTour(int? id)
        {
            DatTour a = new DatTour();
            
            if (id==null)
            {
                return NotFound();
            }
            var Tourdetail = _db.Tours.Where(n => n.MaTuyenDuong == id).ToList();
            var tuyenduong = _db.TuyenDuongs.SingleOrDefault(n => n.MaTuyenDuong == id);
            ViewBag.image = tuyenduong.Anh;
            return View(Tourdetail);
        }
        [HttpGet]
        public IActionResult booking(int ?id,string image,string tuyenduong,string noidung)
        {
            var Tourdetail = _db.Tours.SingleOrDefault(n=>n.MaTour==id);
            ViewBag.image = image;
            ViewBag.id = Tourdetail.MaTour;
            ViewBag.tuyenduong = tuyenduong;
            ViewBag.noidung = noidung;
            return View();
          
        }

        [HttpPost]
        public async Task<IActionResult> booking (int id,ChiTietDatTour ctdt)
        {
            DatTour dattour = new DatTour();
            if(ModelState.IsValid)
            {
                dattour.NgayDat = DateTime.Now.ToString();
                dattour.MaKH = 1;
                _db.DatTours.Add(dattour);
                await _db.SaveChangesAsync();
                ctdt.MaDat = dattour.MaDat;
                ctdt.MaTour = id;
                _db.ChiTietDatTours.Add(ctdt);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        
       
    }
}