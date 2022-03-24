using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_02.Models;

namespace MVC_02.Data
{
    public class contextoAplicacion : DbContext
    {
        //Constructor
        public contextoAplicacion(DbContextOptions<contextoAplicacion> options) : base(options)
        {

        }
        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
