using CRUD_Alumnos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUD_Alumnos.Controllers
{
    public class DocenteAPIController : ApiController
    {
        [ResponseType(typeof(DocenteCE))]
        public IEnumerable<DocenteCE> Get()
        {
            try
            {
                string sql = @"
                        SELECT D.Id, D.Nombres, D.Apellidos, C.Nombre NombreCiudad, D.CodCiudad
                        FROM Docente D
                        INNER JOIN Ciudad C ON C.Id = D.CodCiudad";
                using (var db = new AlumnosContext())
                {
                    return db.Database.SqlQuery<DocenteCE>(sql).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [ResponseType(typeof(DocenteCE))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"
                        SELECT D.Id, D.Nombres, D.Apellidos, C.Nombre NombreCiudad, D.CodCiudad
                        FROM Docente D
                        INNER JOIN Ciudad C ON C.Id = D.CodCiudad";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<DocenteCE>(sql).Where(dc => dc.Id == id).First());
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] JObject jsonD)
        {
            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    Docente d = JsonConvert.DeserializeObject<Docente>(jsonD.ToString());
                    db.Docente.Add(d);
                    db.SaveChanges();
                    return Ok(d);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}