using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDuLich.Data;
using WebDuLich.Models.DataModel;
namespace WebDuLich.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
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





        }
    }
}