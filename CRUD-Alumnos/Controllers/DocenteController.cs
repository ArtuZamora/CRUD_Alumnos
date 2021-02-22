using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Index()
        {
            try
            {
                string sql = @"
            SELECT D.Id, D.Nombres, D.Apellidos, C.Nombre NombreCiudad
            FROM Docente D
            INNER JOIN Ciudad C ON C.Id = D.CodCiudad";
                using (var db = new AlumnosContext())
                {
                    return View(db.Database.SqlQuery<DocenteCE>(sql).ToList());
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
        public ActionResult Agregar(Docente d)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    db.Docente.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar el docente - " + ex);
                return View();
            }
        }

        public ActionResult ListaCiudades()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Ciudad.ToList());
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Docente doc = db.Docente.Find(id);
                    return View(doc);
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
        public ActionResult Editar(Docente d)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                using (var db = new AlumnosContext())
                {
                    Docente doc = db.Docente.Find(d.Id);
                    doc.Nombres = d.Nombres;
                    doc.Apellidos = d.Apellidos;
                    doc.CodCiudad = d.CodCiudad;
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
                Docente doc = db.Docente.Find(id);
                doc.NombreCiudad = NombreCiudad(doc.CodCiudad);
                return View(doc);
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new AlumnosContext())
            {
                Docente doc = db.Docente.Find(id);
                db.Docente.Remove(doc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public static string NombreCiudad(int CodCiudad)
        {
            using (var db = new AlumnosContext())
            {
                return db.Ciudad.Find(CodCiudad).Nombre;
            }
        }
    }
}