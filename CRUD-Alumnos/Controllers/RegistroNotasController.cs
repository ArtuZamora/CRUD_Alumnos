using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class RegistroNotasController : Controller
    {
        // GET: Docente
        public ActionResult Index()
        {
            try
            {
                string sql = @"
            SELECT RN.Id, CONCAT(A.Nombres,' ',A.Apellidos) AS NombreAlumno,
            M.Nombre AS NombreMateria, RN.Nota1, RN.Nota2, RN.Nota3, RN.Nota4, RN.Periodo
            FROM RegistroNotas RN
            INNER JOIN Alumno A ON A.Id = RN.CodAlumno
            INNER JOIN Materia M ON M.Id = RN.CodMateria";
                using (var db = new AlumnosContext())
                {
                    return View(db.Database.SqlQuery<RegistroNotasCE>(sql).ToList());
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
        public ActionResult Agregar(RegistroNotas rn)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    db.RegistroNotas.Add(rn);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar las notas - " + ex);
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    RegistroNotas rnn = db.RegistroNotas.Find(id);
                    return View(rnn);
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
        public ActionResult Editar(RegistroNotas rn)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                using (var db = new AlumnosContext())
                {
                    RegistroNotas rnn = db.RegistroNotas.Find(rn.Id);
                    rnn.Nota1 = rn.Nota1;
                    rnn.Nota2 = rn.Nota2;
                    rnn.Nota3 = rn.Nota3;
                    rnn.Nota4 = rn.Nota4;
                    rnn.Periodo = rn.Periodo;
                    rnn.CodMateria = rn.CodMateria;
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
                RegistroNotas rnn = db.RegistroNotas.Find(id);
                rnn.NombreAlumno = NombreAlumno(rnn.CodAlumno);
                rnn.NombreMateria = NombreMateria(rnn.CodMateria);
                return View(rnn);
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new AlumnosContext())
            {
                RegistroNotas rnn = db.RegistroNotas.Find(id);
                db.RegistroNotas.Remove(rnn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public static string NombreMateria(int CodMateria)
        {
            using (var db = new AlumnosContext())
            {
                return db.Materia.Find(CodMateria).Nombre;
            }
        }
        public static string NombreAlumno(int CodAlumno)
        {
            using (var db = new AlumnosContext())
            {
                return db.Alumno.Find(CodAlumno).NombreCompleto;
            }
        }
        public ActionResult ListaMaterias()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Materia.ToList());
            }
        }
        public ActionResult ListaAlumnos()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Alumno.ToList());
            }
        }
    }
}