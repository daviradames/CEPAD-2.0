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
    public class Tipo_AtendimentoController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();

        // GET: Tipo_Atendimento
        public ActionResult Index()
        {
            return View(db.Tipo_Atendimento.ToList());
        }

        // GET: Tipo_Atendimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Atendimento tipo_Atendimento = db.Tipo_Atendimento.Find(id);
            if (tipo_Atendimento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Atendimento);
        }

        // GET: Tipo_Atendimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Atendimento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TA,Consulta,Castração")] Tipo_Atendimento tipo_Atendimento)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Atendimento.Add(tipo_Atendimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Atendimento);
        }

        // GET: Tipo_Atendimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Atendimento tipo_Atendimento = db.Tipo_Atendimento.Find(id);
            if (tipo_Atendimento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Atendimento);
        }

        // POST: Tipo_Atendimento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TA,Consulta,Castração")] Tipo_Atendimento tipo_Atendimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Atendimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Atendimento);
        }

        // GET: Tipo_Atendimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Atendimento tipo_Atendimento = db.Tipo_Atendimento.Find(id);
            if (tipo_Atendimento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Atendimento);
        }

        // POST: Tipo_Atendimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Atendimento tipo_Atendimento = db.Tipo_Atendimento.Find(id);
            db.Tipo_Atendimento.Remove(tipo_Atendimento);
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
