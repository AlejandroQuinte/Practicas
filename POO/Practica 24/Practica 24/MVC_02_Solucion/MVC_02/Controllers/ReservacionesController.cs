using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_02.Models;
using MVC_02.Data;

namespace MVC_02.Controllers
{
    public class ReservacionesController : Controller
    {

        private readonly contextoAplicacion _contexto;

        public ReservacionesController(contextoAplicacion context)
        {
            _contexto = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Reservacion> listaReservacion = _contexto.Reservacion;
            return View(listaReservacion);
        }
    }
}
