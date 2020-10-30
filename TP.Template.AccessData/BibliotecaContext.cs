using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TP.Template.AccessData
{
    public class BibliotecaContext:DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }
       
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<EstadoAlquiler> EstadoAlquileres { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            builder.Entity<Libro>().HasData(
            new Libro("1", "El Principito", "Antoine de Saint-Exupéry", "Reynal & Hitchcock", 1, "https://imagessl4.casadellibro.com/a/l/t7/94/9788478887194.jpg"),      
            new Libro("2", "Harry Potter y la camara secreta", "J. K. Rowling", "Salamandra", 3, "https://images-na.ssl-images-amazon.com/images/I/91HHems0BVL.jpg"),
            new Libro("3", "El código Da Vinci", "Dan Brown", "Doubleday", 3, "https://www.planetadelibros.com.ar/usuaris/libros/fotos/167/m_libros/portada_el-codigo-da-vinci_dan-brown_201505260959.jpg"),
            new Libro("4", "El Señor de los Anillos", "J.R.R.Tolkien", "George Allen & Unwin", 4, "https://images.cdn1.buscalibre.com/fit-in/360x360/66/1a/661a3760157941a94cb8db3f5a9d5060.jpg"),
            new Libro("5", "Lo que el viento se llevó", "Margaret Mitchell", "Macmillan Publishers", 2, "https://m.media-amazon.com/images/I/517buCKnBjL.jpg")
            );

            builder.Entity<EstadoAlquiler>().HasData(
                new EstadoAlquiler {Id=1, Descripcion="Alquilado"},
                new EstadoAlquiler {Id=2,Descripcion= "Reservado"},
                new EstadoAlquiler {Id = 3, Descripcion = "Cancelado" }
                );
            builder.Entity<Cliente>().HasData(
                new Cliente { Id=1,Nombre="Lucas",Apellido="Olivera",Dni="34124131",Email="l.olivera@gmail.com"}
                );
        }
    }   
}
