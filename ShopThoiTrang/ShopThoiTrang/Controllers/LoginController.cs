using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class LoginController : Controller
    {
        DBShop db = new DBShop();
        // GET: /Login/
        public ActionResult Index()
        {
            if (Session["login"] != null)
            {
                 return RedirectToAction("Index", "Product");
            }
            return View();
        }

        //Kiểm tra thông tin đăng nhập
        [HttpPost]
        public ActionResult checkLogin()
        {
            
            //Request value từ form đăng nhập
            string username = Request["username"];
            string password = Request["password"];
         
            foreach(var admin in db.Admins.ToList())
            {
                //kiểm tra trong table user xem có đúng username và password ko
                if (username.Equals(admin.username) && password.Equals(admin.password))
                {
                    Session["login"] = admin;
                    return RedirectToAction("Index", "Product");//chuyển tới trang quản trị hệ thống
               
                }

            }

            //gửi biến giá trị để check login
            ViewBag.checkLogin = "false";
            return View("Index");
           
        }
        public ActionResult logout()
        {
            Session.Clear();//xoá session hiện tại
            return RedirectToAction("Index", "Login");
        }
	}
}