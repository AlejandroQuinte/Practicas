using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_02.Data;
using MVC_02.Models;

namespace MVC_02.Controllers
{
    public class ClientesController : Controller
    {
        private readonly contextoAplicacion _contexto;

        public ClientesController(contextoAplicacion context)
        {
            _contexto = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> listaCliente = _contexto.Cliente;
            return View(listaCliente);

            
        }
    }
}
