using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploMVC.Models
{
    public class Autor
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(50, ErrorMessage ="El nombre debe tener como máximo 50 caractéres")]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido debe tener como máximo 50 caractéres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")] //Así quiero que se muestre
        public DateTime FechaNacimiento { get; set; }

        [Display(Name ="Lista de Libros")]
        public ICollection<Libro> Libros { get; set; }
    }
}
