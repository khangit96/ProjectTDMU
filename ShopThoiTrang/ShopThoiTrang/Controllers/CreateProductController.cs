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
    
    public class CreateProductController : Controller
    {
        private DBShop db = new DBShop();

        // GET: /CreateProduct/
        //Hiển thị trang quản lí sản phẩm
        public async Task<ActionResult> Index()
        {
            //Kiểm tra session login
            if (Session["login"]!=null)
            {
                var products = db.Products.Include(p => p.ProductCategory);
                return View(await products.ToListAsync());
            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");
            
        }

        // GET: /CreateProduct/Details/5
        //Xem chi tiết sản phẩm
        public async Task<ActionResult> Details(int? id)
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

        // GET: /CreateProduct/Create
        //Tạo mới sản phẩm
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.ProductCategories, "ID", "Name");
            return View();
        }

        // POST: /CreateProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,Descriptions,Image,MoreImages,Price,Quantity,ParentID,MetaTtile,Detail,CreatedDate,Status,TopNew,DecreasePrice,TopDecrease")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.ProductCategories, "ID", "Name", product.ParentID);
            return View(product);
        }

        // GET: /CreateProduct/Edit/5
        //Chỉnh sữa sản phẩm
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.ParentID = new SelectList(db.ProductCategories, "ID", "Name", product.ParentID);
            return View(product);
        }

        // POST: /CreateProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Name,Descriptions,Image,MoreImages,Price,Quantity,ParentID,MetaTtile,Detail,CreatedDate,Status,TopNew,DecreasePrice,TopDecrease")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.ProductCategories, "ID", "Name", product.ParentID);
            return View(product);
        }

        // GET: /CreateProduct/Delete/5
        //Xoá sản phẩm
        public async Task<ActionResult> Delete(int? id)
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
    }
}
