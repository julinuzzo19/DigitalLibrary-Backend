using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Domain.DTOs
{
    public class AlquilerDto
    {
        public string FechaAlquiler { get; set; }
        public string FechaReserva { get; set; }
        public int ClienteId { get; set; }
        public string ISBN { get; set; }

    }
}
