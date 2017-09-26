﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyHealthyFinances.Models;

namespace MyHealthyFinances.Controllers
{
    public class GroupTypesController : Controller
    {
        private HealthyFinancesDataEntities db = new HealthyFinancesDataEntities();

        // GET: GroupTypes
        public ActionResult Index()
        {
            return View(db.GroupTypes.ToList());
        }

        // GET: GroupTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupType groupType = db.GroupTypes.Find(id);
            if (groupType == null)
            {
                return HttpNotFound();
            }
            return View(groupType);
        }

        // GET: GroupTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] GroupType groupType)
        {
            if (ModelState.IsValid)
            {
                db.GroupTypes.Add(groupType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupType);
        }

        // GET: GroupTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupType groupType = db.GroupTypes.Find(id);
            if (groupType == null)
            {
                return HttpNotFound();
            }
            return View(groupType);
        }

        // POST: GroupTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] GroupType groupType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupType);
        }

        // GET: GroupTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupType groupType = db.GroupTypes.Find(id);
            if (groupType == null)
            {
                return HttpNotFound();
            }
            return View(groupType);
        }

        // POST: GroupTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupType groupType = db.GroupTypes.Find(id);
            db.GroupTypes.Remove(groupType);
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
