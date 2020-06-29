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
    public class AnimalsController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();

        // GET: Animals
        public ActionResult Index()
        {
            var animal = db.Animal.Include(a => a.Cor).Include(a => a.Especie).Include(a => a.Especie1).Include(a => a.Municipe).Include(a => a.porte).Include(a => a.Tipo);
            return View(animal.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cor = new SelectList(db.Cor, "ID_Cor", "Nome_Cor");
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie");
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie");
            ViewBag.ID_Municipe = new SelectList(db.Municipe, "ID_Municipe", "Nome");
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte");
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal");
            return View();
        }

        // POST: Animals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Animal,DT_Nasc,Nome_Animal,Castrado,Pelagem,COD_RGA,Micro_Chip,Sexo,Especificação,ID_Tipo,ID_Porte,ID_Municipe,ID_Especie,ID_Cor")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animal.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cor = new SelectList(db.Cor, "ID_Cor", "Nome_Cor", animal.ID_Cor);
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie", animal.ID_Especie);
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie", animal.ID_Especie);
            ViewBag.ID_Municipe = new SelectList(db.Municipe, "ID_Municipe", "Nome", animal.ID_Municipe);
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte", animal.ID_Porte);
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal", animal.ID_Tipo);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cor = new SelectList(db.Cor, "ID_Cor", "Nome_Cor", animal.ID_Cor);
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie", animal.ID_Especie);
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie", animal.ID_Especie);
            ViewBag.ID_Municipe = new SelectList(db.Municipe, "ID_Municipe", "Nome", animal.ID_Municipe);
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte", animal.ID_Porte);
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal", animal.ID_Tipo);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Animal,DT_Nasc,Nome_Animal,Castrado,Pelagem,COD_RGA,Micro_Chip,Sexo,Especificação,ID_Tipo,ID_Porte,ID_Municipe,ID_Especie,ID_Cor")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cor = new SelectList(db.Cor, "ID_Cor", "Nome_Cor", animal.ID_Cor);
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie", animal.ID_Especie);
            ViewBag.ID_Especie = new SelectList(db.Especie, "ID_Especie", "Nome_Especie", animal.ID_Especie);
            ViewBag.ID_Municipe = new SelectList(db.Municipe, "ID_Municipe", "Nome", animal.ID_Municipe);
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte", animal.ID_Porte);
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal", animal.ID_Tipo);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animal.Find(id);
            db.Animal.Remove(animal);
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
