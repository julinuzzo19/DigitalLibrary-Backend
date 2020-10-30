using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TP2.Template.Domain.Entities
{
    public class Cliente
    {
        public Cliente(int id, string nombre, string apellido, string dni, string email)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Email = email;
        }
        public Cliente() { }

        public int Id { get; set; }

        [Required] public string Nombre { get; set; }
        [Required] public string Apellido { get; set; }
        [Required] public string Dni { get; set; }
        [Required] public string Email { get; set; }

        public List<Alquiler> AlquileresNavigator { get; set; }

    }
}
