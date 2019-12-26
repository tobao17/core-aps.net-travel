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
using WebDuLich.Utility;

namespace WebDuLich.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class quanlyTuyenDuongController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnviroment;

        [BindProperty]
        public TuyenDuongViewModel TuyenDuongVM { get; set; }

        public quanlyTuyenDuongController(ApplicationDbContext db, HostingEnvironment hostingEnviroment)
        {
            _db = db;
            _hostingEnviroment = hostingEnviroment;
            TuyenDuongVM = new TuyenDuongViewModel()
            {
                LoaiTours = _db.LoaiTours.ToList(),
                Sales = _db.Sales.ToList(),
                TuyenDuong = new Models.DataModel.TuyenDuong()
            };
        }
        public async Task<IActionResult> Index()
        {
            var tuyenduong = _db.TuyenDuongs.Include(n => n.LoaiTour)
                .Include(n => n.Sale).OrderByDescending(m => m.MaTuyenDuong);
            return View(await tuyenduong.ToListAsync());
        }

        //Create TuyenDuong
        public IActionResult Create()
        {
            return View(TuyenDuongVM);
        }

        //Post: TD Create
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(TuyenDuongVM);
            }

            _db.TuyenDuongs.Add(TuyenDuongVM.TuyenDuong);
            await _db.SaveChangesAsync();

            //Image being saved
            string webRootPath = _hostingEnviroment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var TuyenDuongFromDb = _db.TuyenDuongs.Find(TuyenDuongVM.TuyenDuong.MaTuyenDuong);

            if (files.Count != 0)
            {
                //image has been uploaded
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, files[0].FileName), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                //TuyenDuongFromDb.Anh = @"\" + SD.ImageFolder + @"\" + TuyenDuongVM.TuyenDuong.MaTuyenDuong + extension;
                TuyenDuongFromDb.Anh = files[0].FileName;
            }
            else
            {
                //when user does not upload image
                TuyenDuongFromDb.Anh = files[0].FileName;
        
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" +  files[0].FileName);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + files[0].FileName);
                TuyenDuongFromDb.Anh = @"\" + SD.ImageFolder + @"\" + files[0].FileName;
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        //GET : Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? MaTuyenDuong)
        {
            if (MaTuyenDuong == null)
            {
                return NotFound();
            }

            TuyenDuongVM.TuyenDuong = await _db.TuyenDuongs.Include(n => n.LoaiTour).Include(n => n.Sale).SingleOrDefaultAsync(m => m.MaTuyenDuong == MaTuyenDuong);

            if (TuyenDuongVM.TuyenDuong == null)
            {
                return NotFound();
            }

            return View(TuyenDuongVM);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int MaTuyenDuong)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var TuyenDuongFromDb = _db.TuyenDuongs.Where(m => m.MaTuyenDuong == TuyenDuongVM.TuyenDuong.MaTuyenDuong).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(TuyenDuongFromDb.Anh);

                    if (System.IO.File.Exists(Path.Combine(uploads, files[0].FileName + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, files[0].FileName + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, files[0].FileName), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    TuyenDuongVM.TuyenDuong.Anh = files[0].FileName;
                }

                if (TuyenDuongVM.TuyenDuong.Anh != null)
                {
                    TuyenDuongFromDb.Anh = TuyenDuongVM.TuyenDuong.Anh;
                }

                TuyenDuongFromDb.TenTuyenDuong = TuyenDuongVM.TuyenDuong.TenTuyenDuong;
                TuyenDuongFromDb.NoiDung = TuyenDuongVM.TuyenDuong.NoiDung;
                TuyenDuongFromDb.SoNgay = TuyenDuongVM.TuyenDuong.SoNgay;
                TuyenDuongFromDb.DiaDiemKhoiHanh = TuyenDuongVM.TuyenDuong.DiaDiemKhoiHanh;
                TuyenDuongFromDb.MaLoai = TuyenDuongVM.TuyenDuong.MaLoai;
                TuyenDuongFromDb.MaKM = TuyenDuongVM.TuyenDuong.MaKM;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(TuyenDuongVM);
        }

        
        public async Task<IActionResult> Delete(int MaTuyenDuong)
        {
            string webRootPath = _hostingEnviroment.WebRootPath;
            TuyenDuong tuyenduong = await _db.TuyenDuongs.FindAsync(MaTuyenDuong);

            if (tuyenduong == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(tuyenduong.Anh);

                if (System.IO.File.Exists(Path.Combine(uploads, tuyenduong.MaTuyenDuong + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, tuyenduong.MaTuyenDuong + extension));
                }
                _db.TuyenDuongs.Remove(tuyenduong);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Search(string search)
        {
           
            ViewBag.search = search;
            List<TuyenDuong> lstsearch = _db.TuyenDuongs.Where(a => a.TenTuyenDuong.Contains(search)).ToList();
            return View("Index", lstsearch);
        }
    }
}