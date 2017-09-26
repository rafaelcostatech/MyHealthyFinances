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
    public class MovementsController : Controller
    {
        private HealthyFinancesDataEntities db = new HealthyFinancesDataEntities();

        // GET: Movements
        public ActionResult Index()
        {
            var movements = db.Movements.Include(m => m.BankAccount).Include(m => m.Group);
            return View(movements.ToList());
        }

        // GET: Movements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movement movement = db.Movements.Find(id);
            if (movement == null)
            {
                return HttpNotFound();
            }
            return View(movement);
        }

        // GET: Movements/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.BankAccounts, "AccountId", "Description");
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Description");
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovementId,GroupId,MovDate,MovValue,MovDescription,AccountId")] Movement movement)
        {
            if (ModelState.IsValid)
            {
                db.Movements.Add(movement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.BankAccounts, "AccountId", "Description", movement.AccountId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Description", movement.GroupId);
            return View(movement);
        }

        // GET: Movements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movement movement = db.Movements.Find(id);
            if (movement == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.BankAccounts, "AccountId", "Description", movement.AccountId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Description", movement.GroupId);
            return View(movement);
        }

        // POST: Movements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovementId,GroupId,MovDate,MovValue,MovDescription,AccountId")] Movement movement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.BankAccounts, "AccountId", "Description", movement.AccountId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Description", movement.GroupId);
            return View(movement);
        }

        // GET: Movements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movement movement = db.Movements.Find(id);
            if (movement == null)
            {
                return HttpNotFound();
            }
            return View(movement);
        }

        // POST: Movements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movement movement = db.Movements.Find(id);
            db.Movements.Remove(movement);
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
