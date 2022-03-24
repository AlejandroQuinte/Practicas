using EjemploMVC.Models;
using Microsoft.EntityFrameworkCore;
namespace EjemploMVC.Data {
    public class conextoAplicacion: DbContext {
        //propiedades
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Autor> Autor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        }
    }
}
