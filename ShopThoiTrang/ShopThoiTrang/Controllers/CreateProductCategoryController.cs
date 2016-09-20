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
    public class CreateProductCategoryController : Controller
    {
        private DBShop db = new DBShop();

        // GET: /CreateProductCategory/
        public async Task<ActionResult> Index()
        {
            if (Session["login"] != null)
            {
                var productcategories = db.ProductCategories.Include(p => p.Category);
                return View(await productcategories.ToListAsync());
            }
             return RedirectToRoute("Login", "Index");
         
        }

        // GET: /CreateProductCategory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = await db.ProductCategories.FindAsync(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        // GET: /CreateProductCategory/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: /CreateProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,ParentID")] ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productcategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.Categories, "ID", "Name", productcategory.ParentID);
            return View(productcategory);
        }

        // GET: /CreateProductCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = await db.ProductCategories.FindAsync(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.Categories, "ID", "Name", productcategory.ParentID);
            return View(productcategory);
        }

        // POST: /CreateProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Name,ParentID")] ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productcategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.Categories, "ID", "Name", productcategory.ParentID);
            return View(productcategory);
        }

        // GET: /CreateProductCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = await db.ProductCategories.FindAsync(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        // POST: /CreateProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductCategory productcategory = await db.ProductCategories.FindAsync(id);
            db.ProductCategories.Remove(productcategory);
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
