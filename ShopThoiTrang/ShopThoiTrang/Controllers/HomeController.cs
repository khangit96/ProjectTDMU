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
            ViewBag.productList = GetAllProduct();
            return View();
        }

        //Trả về View xem sản phẩm theo danh mục
        public ActionResult ViewByProductCategory(String productCategoryName, int productCategoryID)
        {
           ViewBag.productList = GetProductByCategory(productCategoryID);
           ViewBag.productCategoryName =db.ProductCategories.Find(productCategoryID).Name;
            return View();
        }

        //Lấy tất cả sản phẩm theo danh mục
        public List<Product> GetProductByCategory(int productCategoryID)
        {
            return db.Products.Where(x => x.ParentID == productCategoryID).ToList();
        }
        //Hàm lấy danh mục sản phẩm
        public List<ProductCategory> GetAllProductCategory()
        {
            return db.ProductCategories.ToList();
        }
        public List<Product> GetAllProduct()
        {
            return db.Products.ToList();
        }
        //Hàm lấy danh sách những sản phẩm mới
        public List<Product> GetNewProduct()
        {

            return db.Products.ToList();
        }
        //Hàm lấy danh sách những sản phẩm giảm giá
        public List<Product> GetDecrease()
        {
            return db.Products.ToList();
         
        }

        //Hàm xem chi tiết sản phẩm
        public ActionResult ViewProductDetail(int id)
        {
            ViewBag.product = db.Products.Find(id);
            return View();
        }

	}
}