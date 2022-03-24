using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EjemploMVC.Models; 

namespace EjemploMVC.Data
{
    public class contextoAplicacion : DbContext
    {
        //Constructor
        public contextoAplicacion(DbContextOptions<contextoAplicacion> options) : base(options)
        {

        }

        //Propiedades
        public DbSet<Libro> Libro { get; set; }

        public DbSet<Autor> Autor { get; set; }
    }
}
