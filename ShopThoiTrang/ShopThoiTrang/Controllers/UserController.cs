﻿using System;
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
    public class UserController : Controller
    {
        private DBShop db = new DBShop();

        // GET: /User/
        public async Task<ActionResult> Index()
        {
            
            if (Session["login"] != null)
            {
                return View(await db.Users.ToListAsync());
            }
            //chuyển về trang login
            return RedirectToRoute("Login", "Index");
        }

        // GET: /User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
         
            return RedirectToRoute("Login", "Index");

        }

        // GET: /User/Create
        public ActionResult Create()
        {
            if (Session["login"] != null)
            {
                return View();                
            }
            return RedirectToRoute("Login", "Index");           
        }

     
        [HttpPost]//Lấy dữ liệu từ form create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,username,password")] User user)
        {
            if (Session["login"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            return RedirectToRoute("Login", "Index");           

           
        }

        // GET: /User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
          
            return RedirectToRoute("Login", "Index");           

        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,username,password")] User user)
        {
            if (Session["login"]!=null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            return RedirectToRoute("Login", "Index");           

           
        }

        // GET: /User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["login"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
           
            return RedirectToRoute("Login", "Index");           

        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (Session["login"] != null)
            {
                User user = await db.Users.FindAsync(id);
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToRoute("Login", "Index");           

           
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