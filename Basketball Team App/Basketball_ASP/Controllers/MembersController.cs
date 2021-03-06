﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Basketball_ASP.Models;

namespace Basketball_ASP.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private Entities2 db = new Entities2();
        private Entities1 db1 = new Entities1();
        public ViewModel model = new ViewModel();

        // GET: Members
        public async Task<ActionResult> Index()
        {
            AspNetUser aspNetUser = new AspNetUser();
            Game game = new Game();

            model.AspNetUsers = await db1.AspNetUsers.ToListAsync();
            model.Games = await db.Games.ToListAsync();

            return View(model);
        }

        // GET: Members/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = await db1.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,UserRole")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db1.AspNetUsers.Add(aspNetUser);
                await db1.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aspNetUser);
        }

        // GET: Members/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = await db1.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,UserRole")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db1.Entry(aspNetUser).State = EntityState.Modified;
                await db1.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: Members/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = await db1.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            AspNetUser aspNetUser = await db1.AspNetUsers.FindAsync(id);
            db1.AspNetUsers.Remove(aspNetUser);
            await db1.SaveChangesAsync();
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
