using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TP2.Template.Domain.Entities
{
    public class Libro
    {
        public Libro(string id, string titulo, string autor, string editorial, Nullable<int> stock, string imagen)
        {
            this.ISBN = id;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editorial = editorial;
            this.Stock = stock;
            this.Imagen = imagen;
        }
        public Libro() { }

        [Required] [Key] public string ISBN { get; set; }
        [Required] public string Titulo { get; set; }
        [Required] public string Autor { get; set; }
        [Required] public string Editorial { get; set; }
        public Nullable<int> Stock { get; set; }
        [Required] public string Imagen { get; set; }

        public List<Alquiler> AlquilerNavigator { get; set; }
    }
}
