using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TP2.Template.Domain.Entities
{
    public class EstadoAlquiler
    {
        public EstadoAlquiler() { }

        public int Id { get; set; }
        [Required] public string Descripcion { get; set; }

        public List<Alquiler> AlquilerNavigator { get; set; }
    }
}
