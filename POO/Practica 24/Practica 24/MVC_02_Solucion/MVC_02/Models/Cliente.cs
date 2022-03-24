using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_02.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "El nombre debe del cliente tener un máximo de 20 caractéres")]
        public string NombreCliente { get; set; }

        [StringLength(20, ErrorMessage = "Los apellidos debe del cliente tener un máximo de 20 caractéres")]
        public string Apellidos { get; set; }

        [StringLength(500, ErrorMessage = "La dirección debe del cliente tener un máximo de 500 caractéres")]
        public string DireccionExacta { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono debe del cliente tener un máximo de 20 caractéres")]
        public string Telefono { get; set; }

        [StringLength(30, ErrorMessage = "El e-mail debe del cliente tener un máximo de 30 caractéres")]
        public string Email { get; set; }

        [Display(Name = "Lista de Reservaciones")]
        public ICollection<Reservacion> Reservacion { get; set; }
    }
}
