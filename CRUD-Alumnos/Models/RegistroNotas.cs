//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Alumnos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistroNotas
    {
        public int Id { get; set; }
        public int CodMateria { get; set; }
        public int CodAlumno { get; set; }
        public string Periodo { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int Nota3 { get; set; }
        public int Nota4 { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
