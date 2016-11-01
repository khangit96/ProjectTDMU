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
            int quantity = Int16.Parse(Request["quantity"]);
            ViewBag.product = product;

            //Nếu sản phẩm giảm giá
            decimal totalPrice;
            if (product.TopDecrease == "true")
            {
                totalPrice = quantity * (Decimal)product.DecreasePrice;
            }
            else
            {
                totalPrice = quantity * (Decimal)product.Price;
            }
            Cart cart = new Cart(product, quantity, totalPrice);
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

        //Cập nhật giỏ hàng
        public ActionResult UpdateCart()
        {
            string[] quantities =Request.Form.GetValues("quantity");
            List < Cart >cartList= Session["cart"] as List<Cart>;
            for (int i = 0; i < cartList.Count;i++ )
            {
                //Cập nhật lại số lượng
                cartList[i].quantity = Int16.Parse(quantities[i]);
                //Cập nhật lại giá
                  Product product=cartList[i].product;
                  int quantity=cartList[i].quantity;
                  decimal totalPrice;
                  if (product.TopDecrease == "true")
                   {
                       totalPrice = quantity * (Decimal)product.DecreasePrice;
                  }
                  else
                  {
                      totalPrice = quantity * (Decimal)product.Price;
                  }
                  cartList[i].totalPrice = totalPrice;
            }
            Session["cart"] = cartList;
             return RedirectToAction("Index");
             
        }
	}
}