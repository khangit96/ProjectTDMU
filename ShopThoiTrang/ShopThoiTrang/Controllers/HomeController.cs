using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        DBShop db = new DBShop();

        //Trang chủ
        public ActionResult Index()
        {
            ViewBag.productList = getAllProduct();
            return View();
        }

        //Hàm lấy danh mục sản phẩm
        public List<ProductCategory> getAllProductCategory()
        {
            return db.ProductCategories.ToList();
        }
        public List<Product> getAllProduct()
        {
            return db.Products.ToList();
        }
        //Hàm lấy danh sách những sản phẩm mới
        public List<Product> getNewProduct()
        {

            return db.Products.ToList();
        }
        //Hàm lấy danh sách những sản phẩm giảm giá
        public List<Product> getDecrease()
        {
            return db.Products.ToList();
         
        }
	}
}