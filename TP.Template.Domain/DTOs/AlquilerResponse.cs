namespace TP2.Template.Domain.DTOs
{
    public class AlquilerResponse
    {
        public int Id { get; set; }
        public string FechaAlquiler { get; set; }
        public string FechaReserva { get; set; }
        public string FechaDevolucion { get; set; }
        public int ClienteId { get; set; }
        public string LibroISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int Stock { get; set; }
    }
}
