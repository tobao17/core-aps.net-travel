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
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ToursController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            var tuyenduong = _db.TuyenDuongs.Include(m => m.Sale);

            return View(tuyenduong.ToList());
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
            ViewBag.noidung = tuyenduong.NoiDung;
            return View(Tourdetail);
        }
        [HttpGet]
        public async Task<IActionResult> booking(int ?id)
        {
            string id_text = HttpContext.Session.GetString("khachhangid");
            if (id_text == null || id_text == "")
            {
                return RedirectToAction("Index", "Login");
            }
            var Tourdetail = _db.Tours.SingleOrDefault(n => n.MaTour == id);
           ViewBag.matuyenduong = Tourdetail.MaTuyenDuong;
            var chitiet = _db.BinhLuans.Include(m => m.TuyenDuong)
                .Include(m => m.KhachHang).OrderByDescending(n=>n.MaBL);
            ViewBag.soluongbinhluan = _db.BinhLuans.Where(n => n.MaTuyenDuong == Tourdetail.MaTuyenDuong).Count();




            ViewBag.id = Tourdetail.MaTour;
         
            ViewBag.giatour = Tourdetail.GiaTour;
            return View(await chitiet.ToListAsync());
          
        }

        [HttpPost]
        public async Task<IActionResult> booking (int id,ChiTietDatTour ctdt,string giatour)
        {
            DatTour dattour = new DatTour();
            if(ModelState.IsValid)
            {
                dattour.NgayDat = DateTime.Now.ToString();
                dattour.MaKH =int.Parse( HttpContext.Session.GetString("khachhangid"));
                _db.DatTours.Add(dattour);
                await _db.SaveChangesAsync();
                ctdt.MaDat = dattour.MaDat;
                ctdt.MaTour = id;
                ctdt.TongTien = (int.Parse(giatour) * ctdt.SoNguoiDiTour).ToString();
                _db.ChiTietDatTours.Add(ctdt);
                await _db.SaveChangesAsync();
                int a = int.Parse(HttpContext.Session.GetString("count_tour"));
                HttpContext.Session.SetString("count_tour", (a+1).ToString());
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> comment(BinhLuan bl,int MaTour)
        {

            //dattour.NgayDat = DateTime.Now.ToString();
            //dattour.MaKH = int.Parse(HttpContext.Session.GetString("khachhangid"));
            //_db.DatTours.Add(dattour);
            //await _db.SaveChangesAsync();
            //ctdt.MaDat = dattour.MaDat;
            //ctdt.MaTour = id;
            //ctdt.TongTien = (int.Parse(giatour) * ctdt.SoNguoiDiTour).ToString();
            //_db.ChiTietDatTours.Add(ctdt);
            //await _db.SaveChangesAsync();
            //int a = int.Parse(HttpContext.Session.GetString("count_tour"));
            //HttpContext.Session.SetString("count_tour", (a + 1).ToString());
            int id = MaTour;
            string id_text = HttpContext.Session.GetString("khachhangid");
            bl.MaKH = int.Parse(id_text);
            _db.BinhLuans.Add(bl);
            await _db.SaveChangesAsync();
            return RedirectToAction("booking", "Tours",new {id=MaTour });

        }


        public IActionResult TimKiem(IFormCollection f)
        {

            string sTenTuyenDuong = f["TenTuyenDuong"].ToString();
            if (sTenTuyenDuong.Length > 0)
            {
                List<TuyenDuong> listTuyenDuongs = _db.TuyenDuongs.Where(n => n.TenTuyenDuong.Contains(sTenTuyenDuong)).ToList();
                if (listTuyenDuongs.Count > 0)
                {
                    ViewBag.TenTuyenDuong = sTenTuyenDuong;
                    ViewBag.ThongBao = "Kết quả tìm kiếm cho " + "'" + sTenTuyenDuong + "' !";
                    return View(listTuyenDuongs);
                }
                else
                {
                    ViewBag.ThongBao = "Không tìm thấy sách nào có tên " + "'" + sTenTuyenDuong + "' !";
                    return View(listTuyenDuongs);
                }
            }
            return RedirectToAction("Index", "Tours");
        }
    }
}