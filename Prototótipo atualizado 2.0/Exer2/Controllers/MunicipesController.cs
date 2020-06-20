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
    public class MunicipesController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();

        // GET: Municipes
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                var municipe = db.Municipes.Include(m => m.Usuario);
                return View(municipe.ToList());              
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

           
        }

        // GET: Municipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipe municipe = db.Municipes.Find(id);
            if (municipe == null)
            {
                return HttpNotFound();
            }
            return View(municipe);
        }

        // GET: Municipes/Create
        public ActionResult Create()
        {

            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "USuario1");
                return View();
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
            
        }

        // POST: Municipes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Municipe,Nome,RG,DT_Nasc,Tel_Fixo,UF,Rua,NR_Casa,Bairro,Celular,CPF,ID_Usuario,Email,Cidade,Complemento")] Municipe municipe)
        {
            if (ModelState.IsValid)
            {
                db.Municipes.Add(municipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "USuario1", municipe.ID_Usuario);
            return View(municipe);
        }

        // GET: Municipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipe municipe = db.Municipes.Find(id);
            if (municipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "USuario1", municipe.ID_Usuario);
            return View(municipe);
        }

        // POST: Municipes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Municipe,Nome,RG,DT_Nasc,Tel_Fixo,UF,Rua,NR_Casa,Bairro,Celular,CPF,ID_Usuario,Email,Cidade,Complemento")] Municipe municipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "USuario1", municipe.ID_Usuario);
            return View(municipe);
        }

        // GET: Municipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipe municipe = db.Municipes.Find(id);
            if (municipe == null)
            {
                return HttpNotFound();
            }
            return View(municipe);
        }

        // POST: Municipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipe municipe = db.Municipes.Find(id);
            db.Municipes.Remove(municipe);
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
