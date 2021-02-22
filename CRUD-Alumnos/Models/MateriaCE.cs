using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CRUD_Alumnos.Models
{
    public class MateriaCE
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese nombre de la materia")]
        public string Nombre { get; set; }
    }
}