using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Template.Domain.DTOs
{
   public  class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}
