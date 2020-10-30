using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Template.Domain.DTOs
{
    public class EstadoAlquilerDto
    {
        public EstadoAlquilerDto(string estado)
        {
            this.Descripcion = estado;
        }

        public string Descripcion { get; set; }
    }
}
