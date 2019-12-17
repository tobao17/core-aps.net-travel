using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDuLich.Data;
using WebDuLich.Models;
using WebDuLich.Models.DataModel;

namespace WebDuLich.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(KhachHang custumer)
        {

            ViewBag.thongbao = "them tai khoan thanh cong";
            _db.KhachHangs.Add(custumer);
            _db.SaveChanges();
            //co the lay bang form conection 
            return View();

        }
        [HttpPost]
        public IActionResult dangnhap (IFormCollection f)

        {
            string name = f["name"].ToString();
            string pass = f["pass"].ToString();
         
            {
                KhachHang tv = _db.KhachHangs.SingleOrDefault(n => n.Username == name);
                if (tv != null)
                {
                    HttpContext.Session.SetString("hoten","bao");
                   return RedirectToAction("Index", "Home");
                }
            }
            //else if (f["admin"] != null)
            //{
            //    ADMIN tv = db.USERs.SingleOrDefault(n => n.name == name && n.pass == pass);
            //    if (tv != null)
            //    {
            //        Session["taikhoanad"] = tv.name;
            //        Session["taikhoanidad"] = tv.adminid;
            //        return RedirectToAction("Index", "quanlysanpham", new { area = "admin" });
            //    }

            //}


            return View();
        }
        public ActionResult dangxuat(FormCollection f)

        {

            //Session["taikhoan"] = null;
            //Session["taikhoanid"] = null;


            return RedirectToAction("Index", "Home");
        }
        public ActionResult quenmatkhau()
        {
            return View();
        }
    }
}