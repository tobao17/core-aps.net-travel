using System;
using System.Collections.Generic;
using System.IO;
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
    public class quanlyTourController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnviroment;

        [BindProperty]
        public TourViewModel TourVM { get; set; }

        public quanlyTourController(ApplicationDbContext db, HostingEnvironment hostingEnviroment)
        {
            _db = db;
            _hostingEnviroment = hostingEnviroment;
            TourVM = new TourViewModel()
            {
                TuyenDuongs = _db.TuyenDuongs.ToList(),
                Tour = new Models.DataModel.Tour()
            };
        }
        public async Task<IActionResult> Index()
        {
            var tour = _db.Tours.Include(n => n.TuyenDuong);
            return View(await tour.ToListAsync());
        }

        //Create TuyenDuong
        public IActionResult Create()
        {
            return View(TourVM);
        }

        //Post: TD Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(TourVM);
            }

            _db.Tours.Add(TourVM.Tour);
            await _db.SaveChangesAsync();           
            return RedirectToAction(nameof(Index));
        }


        //GET : Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? MaTour)
        {
            if (MaTour == null)
            {
                return NotFound();
            }

            TourVM.Tour = await _db.Tours.Include(n => n.TuyenDuong).SingleOrDefaultAsync(m => m.MaTour == MaTour);

            if (TourVM.Tour == null)
            {
                return NotFound();
            }

            return View(TourVM);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int MaTour)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var TourFromDb = _db.Tours.Where(m => m.MaTour == TourVM.Tour.MaTour).FirstOrDefault();

                TourFromDb.MaTuyenDuong = TourVM.Tour.MaTuyenDuong;
                TourFromDb.GiaTour = TourVM.Tour.GiaTour;
                TourFromDb.SoNguoiToiDa = TourVM.Tour.SoNguoiToiDa;
                TourFromDb.NgayKhoiHanh = TourVM.Tour.NgayKhoiHanh;
                TourFromDb.NgayKetThuc = TourVM.Tour.NgayKetThuc;
                TourFromDb.GioDi=TourVM.Tour.GioDi;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(TourVM);
        }



        //Delete
        public async Task<IActionResult> Delete(int MaTour)
        {
            string webRootPath = _hostingEnviroment.WebRootPath;
            Tour tour = await _db.Tours.FindAsync(MaTour);
                _db.Tours.Remove(tour);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            
        }

        //Search
        public IActionResult Search(string search)
        {
            //var t = from m in _db.Tours
            //         select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    t = t.Where(s => s.TuyenDuong.TenTuyenDuong.Contains(searchString));
            //}
            ViewBag.search = search;
            List<Tour> lstsearch = _db.Tours.Where(a => a.TuyenDuong.TenTuyenDuong.Contains(search)).ToList();
            //return View(await t.ToListAsync());
            return View("Index", lstsearch);
        }


    }
}