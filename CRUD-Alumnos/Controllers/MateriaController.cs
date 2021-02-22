using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class MateriaController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    return View(db.Materia.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Materia m)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    db.Materia.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar la materia - " + ex);
                return View();
            }
        }
        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Materia mat = db.Materia.Find(id);
                    return View(mat);
                }
            }
            catch (Exception ex)
            {
                return View();
                throw;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Materia m)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                using (var db = new AlumnosContext())
                {
                    Materia mat = db.Materia.Find(m.Id);
                    mat.Nombre = m.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
                throw;
            }
        }

        public ActionResult Detalles(int id)
        {
            using (var db = new AlumnosContext())
            {
                Materia mat = db.Materia.Find(id);
                return View(mat);
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new AlumnosContext())
            {
                Materia mat = db.Materia.Find(id);
                db.Materia.Remove(mat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}