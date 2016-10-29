using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;
namespace ShopThoiTrang.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            ViewBag.cartList = Session["cart"] as List<Cart>;
            return View();
        }
        public ActionResult AddToCart(int id)
        {
            Product product = new DBShop().Products.Find(id);
            ViewBag.product = product;
            Cart cart = new Cart(product,2,50000);
            if (Session["cart"] != null)
            {
                List<Cart> cartList = Session["cart"] as List<Cart>;
                cartList.Add(cart);
                Session["cart"] = cartList;
            }
            else
            {
                List<Cart> cartList = new List<Cart>();
                cartList.Add(cart);
                Session["cart"] =cartList;

            }
            return RedirectToAction("Index");
         
        }
	}
}