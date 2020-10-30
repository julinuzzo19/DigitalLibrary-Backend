using System.Collections.Generic;
using TP2.Template.Domain.DTOs;

namespace TP2.Template.Domain.Queries
{
    public interface IClienteQueries
    {
        ClienteDto GetClienteById(int id);
        List<ClienteResponse> GetAllClientes(string nombre, string apellido, string dni);

    }
}
