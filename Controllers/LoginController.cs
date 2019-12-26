using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDuLich.Data;
using WebDuLich.Models;
using WebDuLich.Models.DataModel;
<<<<<<< HEAD
using System.Net.Mail;
using WebDuLich.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
=======
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25

namespace WebDuLich.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

<<<<<<< HEAD
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

=======
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(KhachHang custumer)
        {

            ViewBag.thongbao = "them tai khoan thanh cong";
<<<<<<< HEAD
            custumer.HoTen = "";
            custumer.SDT = "";
            custumer.Password = MD5Hash(custumer.Password);
=======
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25
            _db.KhachHangs.Add(custumer);
            _db.SaveChanges();
            //co the lay bang form conection 
            return View();

        }
        [HttpPost]
        public IActionResult dangnhap (IFormCollection f)

        {
            string name = f["name"].ToString();
<<<<<<< HEAD
            string pass = MD5Hash(f["pass"].ToString());


            if (f["customer"] =="")
            {

                KhachHang tv = _db.KhachHangs.Include(m=>m.DatTours).Where(n=>n.Username==name && n.Password==pass).First();

                if (tv != null)
                {
                    HttpContext.Session.SetString("hoten", tv.Username.ToString());
                    HttpContext.Session.SetString("khachhangid", tv.MaKH.ToString());
                    HttpContext.Session.SetString("count_tour", tv.DatTours.Where(n => n.TinhTrang != "DaHuy").Count().ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View();
            }


            else if (f["admin"] == "")
            {
                ADMIN tv = _db.ADMINs.SingleOrDefault(n => n.Username == name && n.Password == pass);
                if (tv != null)
                {
                    HttpContext.Session.SetString("admin", tv.Username.ToString());
                    HttpContext.Session.SetString("adminid", tv.AdminID.ToString());
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

            }
=======
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
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25


            return View();
        }
<<<<<<< HEAD
        public IActionResult partialicon()
        {
           
            return PartialView();
        }
        public IActionResult dangxuat()
=======
        public ActionResult dangxuat(FormCollection f)
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25

        {

            //Session["taikhoan"] = null;
            //Session["taikhoanid"] = null;
<<<<<<< HEAD
            HttpContext.Session.SetString("hoten","");
            HttpContext.Session.SetString("khachhangid","");
=======

>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25

            return RedirectToAction("Index", "Home");
        }
        public ActionResult quenmatkhau()
        {
            return View();
        }
<<<<<<< HEAD
        [HttpPost]
        public ActionResult quenmatkhau(string email)
        {
            KhachHang cus = new KhachHang();
              cus=_db.KhachHangs.SingleOrDefault(n => n.Email == email);
            cus.Password = "dsksjivlais";
            string pass = cus.Password;
            _db.SaveChanges();
            GuiEmail("Thong Bao", email, "Phamtobao99@gmail.com", "17110261", "Your new password:" + pass);
            return Redirect("thongbaoquenmatkhau");

        }
        public ActionResult thongbaoquenmatkhau()
        {
            return View();
        }
        public void GuiEmail(string Title, string ToEmail, string FromEmail, string PassWord, string Content)
        {
            // goi email
            MailMessage mail = new MailMessage();
            mail.To.Add(ToEmail); // Địa chỉ nhận
            mail.From = new MailAddress(ToEmail); // Địa chửi gửi
            mail.Subject = Title; // tiêu đề gửi
            mail.Body = Content; // Nội dung
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; // host gửi của Gmail
            smtp.Port = 587; //port của Gmail
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            (FromEmail, PassWord);//Tài khoản password người gửi
            smtp.EnableSsl = true; //kích hoạt giao tiếp an toàn SSL
            smtp.Send(mail); //Gửi mail đi
        }
=======
>>>>>>> dc56b07597d4a4362228c462516e1c96425e1e25
    }
}