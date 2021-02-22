using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    public class RegistroNotasCE
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Materia")]
        public int CodMateria { get; set; }
        [Required]
        [Display(Name = "Alumno")]
        public int CodAlumno { get; set; }
        [Required]
        [Display(Name = "Periodo")]
        public string Periodo { get; set; }
        [Required]
        [Display(Name = "Nota 1")]
        public int Nota1 { get; set; }
        [Required]
        [Display(Name = "Nota 2")]
        public int Nota2 { get; set; }
        [Required]
        [Display(Name = "Nota 3")]
        public int Nota3 { get; set; }
        [Required]
        [Display(Name = "Nota 4")]
        public int Nota4 { get; set; }

        public string NombreMateria { get; set; }
        public string NombreAlumno { get; set; }
    }
    [MetadataType(typeof(RegistroNotasCE))]
    public partial class RegistroNotas
    {
        public string NombreMateria { get; set; }
        public string NombreAlumno { get; set; }
    }
}