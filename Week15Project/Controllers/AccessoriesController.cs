﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week15Project.Models;

namespace Week15Project.Controllers
{
    public class AccessoriesController : Controller
    {
        private Week15ProjectContext db = new Week15ProjectContext();

        // GET: Accessories
        public ActionResult Index()
        {
            return View(db.Accessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoryID,Nickname,Photo,Type,Color,Season,Occasion")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessories);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoryID,Nickname,Photo,Type,Color,Season,Occasion")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessories);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessories accessories = db.Accessories.Find(id);
            db.Accessories.Remove(accessories);
            db.SaveChanges();
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
