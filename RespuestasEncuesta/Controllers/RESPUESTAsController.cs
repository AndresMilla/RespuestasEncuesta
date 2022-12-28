using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RespuestasEncuesta.Models;

namespace RespuestasEncuesta.Controllers
{
    public class RESPUESTAsController : Controller
    {
        private DB_PROYECTOEntities db = new DB_PROYECTOEntities();

        // GET: RESPUESTAs
        public ActionResult Index()
        {
            var rESPUESTAS = db.RESPUESTAS.Include(r => r.PREGUNTA);
            return View(rESPUESTAS.ToList());
        }

        // GET: RESPUESTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESPUESTA rESPUESTA = db.RESPUESTAS.Find(id);
            if (rESPUESTA == null)
            {
                return HttpNotFound();
            }
            return View(rESPUESTA);
        }

        // GET: RESPUESTAs/Create
        public ActionResult Create()
        {
            ViewBag.IdPreguntas = new SelectList(db.PREGUNTAS, "IdPreguntas", "pregunta1");
            return View();
        }

        // POST: RESPUESTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRespuestas,IdPreguntas,respuesta1,respuesta2,respuesta3,respuesta4,respuesta5")] RESPUESTA rESPUESTA)
        {
            if (ModelState.IsValid)
            {
                db.RESPUESTAS.Add(rESPUESTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPreguntas = new SelectList(db.PREGUNTAS, "IdPreguntas", "pregunta1", rESPUESTA.IdPreguntas);
            return View(rESPUESTA);
        }

        // GET: RESPUESTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESPUESTA rESPUESTA = db.RESPUESTAS.Find(id);
            if (rESPUESTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPreguntas = new SelectList(db.PREGUNTAS, "IdPreguntas", "pregunta1", rESPUESTA.IdPreguntas);
            return View(rESPUESTA);
        }

        // POST: RESPUESTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRespuestas,IdPreguntas,respuesta1,respuesta2,respuesta3,respuesta4,respuesta5")] RESPUESTA rESPUESTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESPUESTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPreguntas = new SelectList(db.PREGUNTAS, "IdPreguntas", "pregunta1", rESPUESTA.IdPreguntas);
            return View(rESPUESTA);
        }

        // GET: RESPUESTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESPUESTA rESPUESTA = db.RESPUESTAS.Find(id);
            if (rESPUESTA == null)
            {
                return HttpNotFound();
            }
            return View(rESPUESTA);
        }

        // POST: RESPUESTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESPUESTA rESPUESTA = db.RESPUESTAS.Find(id);
            db.RESPUESTAS.Remove(rESPUESTA);
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
