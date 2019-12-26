using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDuLich.Data;
using WebDuLich.Models.DataModel;
using WebDuLich.Models.ViewModel;

namespace WebDuLich.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class quanlyDatTourController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnviroment;
        [BindProperty]
        public DatTourViewModel DatTourVM { get; set; }

        public quanlyDatTourController(ApplicationDbContext db, HostingEnvironment hostingEnviroment)
        {
            _db = db;
            _hostingEnviroment = hostingEnviroment;
            DatTourVM = new DatTourViewModel()
            {
                KhachHangs = _db.KhachHangs.ToList(),
                DatTour = new Models.DataModel.DatTour()
            };
        }
        public async Task<IActionResult> Index()
        {
            var datTour = _db.DatTours.Include(n => n.KhachHang);
            return View(await datTour.ToListAsync());
        }

        //Delete
        public async Task<IActionResult> Delete(int MaDat)
        {
            string webRootPath = _hostingEnviroment.WebRootPath;
            DatTour dattour = await _db.DatTours.FindAsync(MaDat);
            _db.DatTours.Remove(dattour);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        //Details
        public IActionResult Details(int? MaDat)
        {
            if (MaDat == null)
            {
                return NotFound();
            }
            List<ChiTietDatTour> Details = _db.ChiTietDatTours.Include(n=>n.Tour.TuyenDuong).Include(n=>n.DatTour).Where(n => n.MaDat == MaDat).ToList();
            ViewBag.Tour = Details[0].Tour.TuyenDuong.TenTuyenDuong;
            ViewBag.NgayKhoiHanh = Details[0].Tour.NgayKhoiHanh;
            ViewBag.NgayKetThuc = Details[0].Tour.NgayKetThuc;
            ViewBag.NgayDat = Details[0].DatTour.NgayDat;
            ViewBag.tenkhachhang = Details[0].HoTen;
            ViewBag.SDT = Details[0].SDT;
            ViewBag.SoNguoiDiTour = Details[0].SoNguoiDiTour;
            ViewBag.TongTien = Details[0].TongTien;
            return View(Details);

        }

        public IActionResult Search(string search)
        {

            ViewBag.search = search;
            List<DatTour> lstsearch = _db.DatTours.Where(a => a.KhachHang.HoTen.Contains(search)).ToList();
            return View("Index", lstsearch);
        }
    }
}