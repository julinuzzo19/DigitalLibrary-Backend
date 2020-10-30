using System;

namespace TP2.Template.Domain.Entities
{
    public class Alquiler
    {
        public Alquiler(int id, Nullable<DateTime> fechalquiler, Nullable<DateTime> fechareserva, Nullable<DateTime> fechadevolucion)
        {
            this.Id = id;
            this.FechaAlquiler = fechalquiler;
            this.FechaReserva = fechareserva;
            this.FechaDevolucion = fechadevolucion;
        }
        public Alquiler() { }

        public int Id { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        //Foreign Keys

        public int ClienteId { get; set; }
        public int EstadoAlquilerId { get; set; }
        public string ISBN { get; set; }

        public Cliente Cliente { get; set; }
        public EstadoAlquiler EstadoAlquiler { get; set; }
        public Libro Libro { get; set; }
    }
}
