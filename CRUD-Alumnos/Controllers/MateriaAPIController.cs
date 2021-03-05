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
    public class MateriaAPIController : ApiController
    {
        [ResponseType(typeof(Materia))]
        public IEnumerable<Materia> Get()
        {
            try
            {
                string sql = @"SELECT * FROM Materia M";
                using (var db = new AlumnosContext())
                {
                    return db.Database.SqlQuery<Materia>(sql).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ResponseType(typeof(Materia))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Materia.Where(m => m.Id == id).ToList().First());
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] JObject jsonM)
        {
            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    Materia m = JsonConvert.DeserializeObject<Materia>(jsonM.ToString());
                    db.Materia.Add(m);
                    db.SaveChanges();
                    return Ok(m);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}