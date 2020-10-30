﻿using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Domain.Queries
{
    public interface IAlquilerQueries
    {
        List<Alquiler> GetAllAlquiler(int estado);
        Alquiler GetAlquilerById(int id);
       Alquiler GetAlquilerById_Isbn(int clienteid, string isbn);
        List<Alquiler> GetLibrosByCliente(int id);
    }
}