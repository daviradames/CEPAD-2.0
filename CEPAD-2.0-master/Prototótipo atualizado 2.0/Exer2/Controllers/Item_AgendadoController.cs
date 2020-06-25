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
    public class Item_AgendadoController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();

        // GET: Item_Agendado
        public ActionResult Index()
        {
            var item_Agendado = db.Item_Agendado.Include(i => i.Agenda).Include(i => i.Animal);
            return View(item_Agendado.ToList());
        }

        // GET: Item_Agendado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Agendado item_Agendado = db.Item_Agendado.Find(id);
            if (item_Agendado == null)
            {
                return HttpNotFound();
            }
            return View(item_Agendado);
        }

        // GET: Item_Agendado/Create
        public ActionResult Create()
        {
            ViewBag.ID_Agenda = new SelectList(db.Agenda, "ID_Agenda", "ID_Agenda");
            ViewBag.ID_Animal = new SelectList(db.Animal, "ID_Animal", "Nome_Animal");
            return View();
        }

        // POST: Item_Agendado/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Protocolo,ID_Agenda,ID_Animal")] Item_Agendado item_Agendado)
        {
            if (ModelState.IsValid)
            {
                db.Item_Agendado.Add(item_Agendado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Agenda = new SelectList(db.Agenda, "ID_Agenda", "ID_Agenda", item_Agendado.ID_Agenda);
            ViewBag.ID_Animal = new SelectList(db.Animal, "ID_Animal", "Nome_Animal", item_Agendado.ID_Animal);
            return View(item_Agendado);
        }

        // GET: Item_Agendado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Agendado item_Agendado = db.Item_Agendado.Find(id);
            if (item_Agendado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Agenda = new SelectList(db.Agenda, "ID_Agenda", "ID_Agenda", item_Agendado.ID_Agenda);
            ViewBag.ID_Animal = new SelectList(db.Animal, "ID_Animal", "Nome_Animal", item_Agendado.ID_Animal);
            return View(item_Agendado);
        }

        // POST: Item_Agendado/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Protocolo,ID_Agenda,ID_Animal")] Item_Agendado item_Agendado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_Agendado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Agenda = new SelectList(db.Agenda, "ID_Agenda", "ID_Agenda", item_Agendado.ID_Agenda);
            ViewBag.ID_Animal = new SelectList(db.Animal, "ID_Animal", "Nome_Animal", item_Agendado.ID_Animal);
            return View(item_Agendado);
        }

        // GET: Item_Agendado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Agendado item_Agendado = db.Item_Agendado.Find(id);
            if (item_Agendado == null)
            {
                return HttpNotFound();
            }
            return View(item_Agendado);
        }

        // POST: Item_Agendado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item_Agendado item_Agendado = db.Item_Agendado.Find(id);
            db.Item_Agendado.Remove(item_Agendado);
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
