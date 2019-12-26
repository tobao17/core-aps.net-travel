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
    public class quanlyKhuyenMaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnviroment;
        [BindProperty]
        public SaleViewModel SaleVM { get; set; }

        public quanlyKhuyenMaiController(ApplicationDbContext db, HostingEnvironment hostingEnviroment)
        {
            _db = db;
            _hostingEnviroment = hostingEnviroment;
            SaleVM = new SaleViewModel()
            {
                Sale = new Models.DataModel.Sale()
            };
        }
        public async Task<IActionResult> Index()
        {
            var sale = _db.Sales; 
            return View(await sale.ToListAsync());
        }
        //Create TuyenDuong
        public IActionResult Create()
        {
            return View(SaleVM);
        }

        //Post: TD Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(SaleVM);
            }

            _db.Sales.Add(SaleVM.Sale);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //GET : Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? MaKM)
        {
            if (MaKM == null)
            {
                return NotFound();
            }

            SaleVM.Sale = await _db.Sales.SingleOrDefaultAsync(m => m.MaKM == MaKM);

            if (SaleVM.Sale == null)
            {
                return NotFound();
            }

            return View(SaleVM);
        }


        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int MaKM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var SaleFromDb = _db.Sales.Where(m => m.MaKM == SaleVM.Sale.MaKM).FirstOrDefault();

                SaleFromDb.Mota = SaleVM.Sale.Mota;
                SaleFromDb.NoiDung = SaleVM.Sale.NoiDung;               
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(SaleVM);
        }


        public async Task<IActionResult> Delete(int MaKM)
        {
            string webRootPath = _hostingEnviroment.WebRootPath;
            var TuyenDuongFromDb = _db.TuyenDuongs.Where(m => m.MaKM == MaKM).ToList();
            var SaleFromDb = _db.Sales.Where(m => m.Mota == "Không").FirstOrDefault();
            foreach( var items in TuyenDuongFromDb)
            {
                items.MaKM = SaleFromDb.MaKM;
            }
            //TuyenDuongFromDb.MaKM = SaleFromDb.MaKM;
            await _db.SaveChangesAsync();

            Sale sale = await _db.Sales.FindAsync(MaKM);
            _db.Sales.Remove(sale);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Search(string search)
        {

            ViewBag.search = search;
            List<Sale> lstsearch = _db.Sales.Where(a => a.Mota.Contains(search)).ToList();
            return View("Index", lstsearch);
        }



    }
}