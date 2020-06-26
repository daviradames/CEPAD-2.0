using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exer2.Models;

namespace Exer2.Controllers
{
    public class CorsController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();

        // GET: Cors
        public ActionResult Index()
        {
            return View(db.Cor.ToList());
        }

        // GET: Cors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cor.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // GET: Cors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cor,Nome_Cor")] Cor cor)
        {
            if (ModelState.IsValid)
            {
                db.Cor.Add(cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cor);
        }

        // GET: Cors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cor.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cor,Nome_Cor")] Cor cor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        // GET: Cors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cor.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cor cor = db.Cor.Find(id);
            db.Cor.Remove(cor);
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
