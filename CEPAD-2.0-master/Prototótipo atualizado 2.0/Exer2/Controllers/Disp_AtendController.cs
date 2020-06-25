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
    public class Disp_AtendController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();

        // GET: Disp_Atend
        public ActionResult Index()
        {
            var disp_Atend = db.Disp_Atend.Include(d => d.porte).Include(d => d.Tipo_Atendimento).Include(d => d.Tipo);
            return View(disp_Atend.ToList());
        }

        // GET: Disp_Atend/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disp_Atend disp_Atend = db.Disp_Atend.Find(id);
            if (disp_Atend == null)
            {
                return HttpNotFound();
            }
            return View(disp_Atend);
        }

        // GET: Disp_Atend/Create
        public ActionResult Create()
        {
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte");
            ViewBag.ID_TA = new SelectList(db.Tipo_Atendimento, "ID_TA", "Consulta");
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal");
            return View();
        }

        // POST: Disp_Atend/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DT_Inicio,DT_Fim,NT_Atend_Ofer,Num_Atend_Agendado,ID_TA,ID_Porte,ID_Tipo")] Disp_Atend disp_Atend)
        {
            if (ModelState.IsValid)
            {
                db.Disp_Atend.Add(disp_Atend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte", disp_Atend.ID_Porte);
            ViewBag.ID_TA = new SelectList(db.Tipo_Atendimento, "ID_TA", "Consulta", disp_Atend.ID_TA);
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal", disp_Atend.ID_Tipo);
            return View(disp_Atend);
        }

        // GET: Disp_Atend/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disp_Atend disp_Atend = db.Disp_Atend.Find(id);
            if (disp_Atend == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte", disp_Atend.ID_Porte);
            ViewBag.ID_TA = new SelectList(db.Tipo_Atendimento, "ID_TA", "Consulta", disp_Atend.ID_TA);
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal", disp_Atend.ID_Tipo);
            return View(disp_Atend);
        }

        // POST: Disp_Atend/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DT_Inicio,DT_Fim,NT_Atend_Ofer,Num_Atend_Agendado,ID_TA,ID_Porte,ID_Tipo")] Disp_Atend disp_Atend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disp_Atend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Porte = new SelectList(db.porte, "ID_Porte", "Nome_Porte", disp_Atend.ID_Porte);
            ViewBag.ID_TA = new SelectList(db.Tipo_Atendimento, "ID_TA", "Consulta", disp_Atend.ID_TA);
            ViewBag.ID_Tipo = new SelectList(db.Tipo, "ID_Tipo", "Nome_Tipo_Animal", disp_Atend.ID_Tipo);
            return View(disp_Atend);
        }

        // GET: Disp_Atend/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disp_Atend disp_Atend = db.Disp_Atend.Find(id);
            if (disp_Atend == null)
            {
                return HttpNotFound();
            }
            return View(disp_Atend);
        }

        // POST: Disp_Atend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            Disp_Atend disp_Atend = db.Disp_Atend.Find(id);
            db.Disp_Atend.Remove(disp_Atend);
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
