using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{

    public class ProductController : Controller
    {
        private DBShop db = new DBShop();

        //Hiển thị trang quản lí sản phẩm     
        public ActionResult Index()
        {
            //Kiểm tra session login
            if (Session["login"] != null)
            {
                var productList = db.Products.ToList();
                ViewBag.productList = productList;
                return View();
            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");
           
        }



        //Tạo mới sản phẩm
        public ActionResult CreateProduct()
        {
            if (Session["login"] != null)
            {
                ViewBag.productCategory = db.ProductCategories.ToList();
                return View("Create");
            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");
        //Thêm sản phẩm 
          
        }
        public ActionResult SaveCreateProduct()
        {
            if (Session["login"] != null)
            {
                String productName = Request["productName"];
                decimal productPrice = Decimal.Parse(Request["productPrice"]);
                String productDescription = WebUtility.HtmlDecode(Request["productDescription"]);
                int productCategory = Int16.Parse(Request["productCategory"]);
                String optIsDescreasePrice = Request["optIsDescreasePrice"];
                decimal descreasePrice = Decimal.Parse(Request["descreasePrice"]);
                String optIsTopNew = Request["optIsTopNew"];
                String currentDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                String productImage = Request["productImage"];
                Product product = new Product(productName, productCategory, productPrice, productImage, productDescription, optIsDescreasePrice, descreasePrice, optIsTopNew);
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute("Login", "Index");

        }
        

        public ActionResult EditProduct(int id)
        {

             if(Session["login"] != null)
            {
                var product = db.Products.Find(id);//tìm sản phẩm cần sữa
                ViewBag.product = product;
                ViewBag.productCategory = db.ProductCategories.ToList();
                return View("Edit");

            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");
          
        }
     

        public ActionResult SaveEditProduct(int id)
        {
            if (Session["login"] != null)
            {

                String productName = Request["productName"];
                decimal productPrice = Decimal.Parse(Request["productPrice"]);
                String productDescription = WebUtility.HtmlDecode(Request["productDescription"]);
                int productCategory = Int16.Parse(Request["productCategory"]);
                String optIsDescreasePrice = Request["optIsDescreasePrice"];
                decimal descreasePrice = Decimal.Parse(Request["descreasePrice"]);
                String optIsTopNew = Request["optIsTopNew"];
                String currentDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                String productImage = Request["productImage"];

                Product product = db.Products.Find(id);
                product.Name=productName;
                product.Price =productPrice;
                product.Image =productImage;
                product.Descriptions = productDescription;
                product.TopNew =optIsTopNew;
                product.ParentID =productCategory;
                product.TopDecrease =optIsDescreasePrice;
                product.DecreasePrice =descreasePrice;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute("Login", "Index");


        }

        public ActionResult DeleteProduct(int id)
        {
            if (Session["login"] != null)
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToRoute("Login", "Index");


        }

        //Xoá sản phẩm
        /*   public async Task<ActionResult> Delete(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Product product = await db.Products.FindAsync(id);
               if (product == null)
               {
                   return HttpNotFound();
               }
               return View(product);
           }

           // POST: /CreateProduct/Delete/5
           [HttpPost, ActionName("Delete")]
           [ValidateAntiForgeryToken]
           public async Task<ActionResult> DeleteConfirmed(int id)
           {
               Product product = await db.Products.FindAsync(id);
               db.Products.Remove(product);
               await db.SaveChangesAsync();
               return RedirectToAction("Index");
           }

           protected override void Dispose(bool disposing)
           {
               if (disposing)
               {
                   db.Dispose();
               }
               base.Dispose(disposing);
           }
       */
    }
}
