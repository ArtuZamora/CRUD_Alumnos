using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    public class DocenteCE
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public int CodCiudad { get; set; }

        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
        public string NombreCiudad { get; set; }
    }

    [MetadataType(typeof(DocenteCE))]
    public partial class Docente
    {
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
        public string NombreCiudad { get; set; }
    }
}