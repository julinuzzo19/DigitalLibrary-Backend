﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.Template.Domain.DTOs
{
    public class ResponseLibro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
    }
}
