using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS4790A3.Models;

namespace CS4790A3.Controllers
{
    public class RunnerController : Controller
    {
        private AnythingFFDbContext db = new AnythingFFDbContext();

        // GET: Runner
        public ActionResult Index()
        {
            return View(AnythingFFRepository.getAllRunners());
           
        }

        // GET: Runner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runner runner = AnythingFFRepository.getRunner(id);
            if (runner == null)
            {
                return HttpNotFound();
            }
            return View(runner);
        }

        // GET: Runner/Create
        public ActionResult Create()
        {
            ViewBag.runnerID = new SelectList(db.lineups, "lineupID", "firstName");
            return View();
        }

        // POST: Runner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "runnerID,firstName,lastName,suffix,anonymous,phone,email,tShirt,emergencyName,emegrgencyPhone,lineupID")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                AnythingFFRepository.addRunner(runner);
                return RedirectToAction("Index");
            }

            ViewBag.runnerID = new SelectList(db.lineups, "lineupID", "firstName", runner.runnerID);
            return View(runner);
        }


        public ActionResult MainPage()
        {

            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MainPage(RunnerLineup runnerLineup)
        {

            if (ModelState.IsValid)
            {
                AnythingFFRepository.addRunnerAndLineup(runnerLineup.runner, runnerLineup.lineup);
                return RedirectToAction("Index");
            }


            return View();

        }


        // GET: Runner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runner runner = AnythingFFRepository.getRunner(id);
            if (runner == null)
            {
                return HttpNotFound();
            }
            ViewBag.runnerID = new SelectList(db.lineups, "lineupID", "firstName", runner.runnerID);
            return View(runner);
        }

        // POST: Runner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "runnerID,firstName,lastName,suffix,anonymous,phone,email,tShirt,emergencyName,emegrgencyPhone,lineupID")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.runnerID = new SelectList(db.lineups, "lineupID", "firstName", runner.runnerID);
            return View(runner);
        }

        // GET: Runner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Runner runner = db.runners.Find(id);
            if (runner == null)
            {
                return HttpNotFound();
            }
            return View(runner);
        }

        // POST: Runner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Runner runner = db.runners.Find(id);
            db.runners.Remove(runner);
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
