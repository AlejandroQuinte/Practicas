using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_02.Models
{
    public class Reservacion
    {
        public int Id { get; set; }
        public DateTime FechaReservacionInicio { get; set; }

        public DateTime FechaReservacionFin { get; set; }

        //[ForeignKey("FK_Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

       
    }
}
