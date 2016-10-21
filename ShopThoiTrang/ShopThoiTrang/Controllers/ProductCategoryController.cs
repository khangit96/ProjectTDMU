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
    public class ProductCategoryController : Controller
    {
        private DBShop db = new DBShop();
        public ActionResult Index()
        {
            //Kiểm tra session login
            if (Session["login"] != null)
            {
                ViewBag.productCategoryList = db.ProductCategories.ToList();
                return View();
            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");

        }

        //Tạo mới sản phẩm
        public ActionResult CreateProductCategory()
        {
            if (Session["login"] != null)
            {
                return View("Create");
            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");

        }
        //Thêm sản phẩm 
        public ActionResult SaveCreateProductCategory()
        {
            if (Session["login"] != null)
            {
                String productCategoryName = Request["productCategoryName"];
                Boolean checkNameCategory = true;
                if(productCategoryName.Equals(""))
                {
                    checkNameCategory = false;
                }
                if (checkNameCategory == false)
                {
                    ViewBag.checkNameCategory=checkNameCategory;
                    return View("Create");

                }

                ProductCategory pc = new ProductCategory();
                pc.Name = productCategoryName;
                db.ProductCategories.Add(pc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute("Login", "Index");

        }


        public ActionResult EditProductCategory(int id)
        {

            if (Session["login"] != null)
            {
                var pc = db.ProductCategories.Find(id);//tìm sản phẩm cần sữa
                ViewBag.pc = pc;
                return View("Edit");

            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");

        }


        public ActionResult SaveEditProductCategory(int id)
        {
            if (Session["login"] != null)
            {
                Boolean checkNameCategory = true;
                String productCategoryName = Request["productCategoryName"];
                if(productCategoryName.Equals(""))
                {
                    checkNameCategory = false;
                }
                if(checkNameCategory==false)
                {
                    ViewBag.checkNameCategory = checkNameCategory;
                    var pc = db.ProductCategories.Find(id);//tìm sản phẩm cần sữa
                    ViewBag.pc = pc;
                    return View("Edit");
                }
                ProductCategory pc1 = db.ProductCategories.Find(id);
                pc1.Name = productCategoryName;
                db.Entry(pc1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToRoute("Login", "Index");


        }

        public ActionResult DeleteProductCategory(int id)
        {
            if (Session["login"] != null)
            {
                ProductCategory pc = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(pc);
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
