using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploMVC.Models
{
    public class Libro
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Se requiere el título")]
        [StringLength(50, ErrorMessage = "El título debe de tener un máximo de 50 caractéres")]
        [Display(Name = "Título")] //Así quiero que se muestre
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Se requiere la descripción")]
        [StringLength(70, ErrorMessage = "La descripción debe de tener un máximo de 70 caractéres")]
        [Display(Name = "Descripción")] //Así quiero que se muestre
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")] //Así quiero que se muestre
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "Se requiere el precio")]
        [Column(TypeName ="Decimal(10,2)")]
        [Display(Name = "Precio")] //Así quiero que se muestre
        public decimal Precio { get; set; }

        //para relacionarlo con profesor
        [ForeignKey("FK_Profesor")]
        public int AutorId { get; set; }

        [Display(Name = "Datso del Autor")]
        public Autor autor { get; set; }

    }//Class libro
}
