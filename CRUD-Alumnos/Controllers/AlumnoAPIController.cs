using CRUD_Alumnos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUD_Alumnos.Controllers
{
    public class AlumnoAPIController : ApiController
    {
        [ResponseType(typeof(AlumnoCE))]
        public IEnumerable<AlumnoCE> Get()
        {
            try
            {
                string sql = @"
                    SELECT A.Id, A.Nombres, A.Apellidos, A.Edad, A.Sexo, A.FechaRegistro, C.Nombre NombreCiudad, A.CodCiudad
                    FROM Alumno A
                    INNER JOIN Ciudad C ON C.Id = A.CodCiudad";
                using (var db = new AlumnosContext())
                {
                    return db.Database.SqlQuery<AlumnoCE>(sql).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [ResponseType(typeof(AlumnoCE))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"
                    SELECT A.Id, A.Nombres, A.Apellidos, A.Edad, A.Sexo, A.FechaRegistro, C.Nombre NombreCiudad, A.CodCiudad
                    FROM Alumno A
                    INNER JOIN Ciudad C ON C.Id = A.CodCiudad";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<AlumnoCE>(sql).Where(al => al.Id == id).First());
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        } 
        public IHttpActionResult Post([FromBody] JObject jsonA)
        {
            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    Alumno a = JsonConvert.DeserializeObject<Alumno>(jsonA.ToString());
                    a.FechaRegistro = DateTime.Now;
                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return Ok(a);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}