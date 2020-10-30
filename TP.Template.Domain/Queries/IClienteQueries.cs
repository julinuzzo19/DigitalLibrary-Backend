using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Domain.Queries
{
    public interface IClienteQueries
    {
        ClienteDto GetClienteById(int id);
        List<ClienteResponse> GetAllClientes(string nombre, string apellido, string dni);

    }
}
