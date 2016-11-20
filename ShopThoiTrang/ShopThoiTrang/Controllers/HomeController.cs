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
            var product=db.Products.Find(id);
            ViewBag.product = product;
            var parentId =product.ParentID;
            ViewBag.productListRelate = db.Products.Where(x => x.ParentID == parentId).ToList();

            //Kiểm tra nếu sản phẩm đã được thêm vào giỏ hàng
            string checkShowAddToCart = "false";
            List<Cart> listCart = new List<Cart>();
            if (Session["cart"]!= null) 
            {
                listCart = Session["cart"] as List<Cart>;
                foreach (var cart in listCart)
                {
                    if (cart.product.ID==id)
                    {
                        checkShowAddToCart ="true";
                        break;
                    }
                }
            }
            ViewBag.checkShowAddToCart = checkShowAddToCart;
            return View();
        }
        
        //Tìm kiếm sản phẩm
        public ActionResult SearchProduct()
        {
            String content = Request["content"];
            if(!content.Equals(""))
            {
                List<ProductCategory> categoryList = db.ProductCategories.Where(t => t.Name.Contains(content)).ToList();
                List<Product> productList = new List<Product>();
                foreach (var cat in categoryList)
                {
                    foreach (var product in db.Products.ToList())
                    {
                        if (product.ParentID == cat.ID)
                        {
                            productList.Add(product);
                        }
                    }
                }
                ViewBag.productResultList = productList;
            }
            return View("Search");
        }
     
	}
}