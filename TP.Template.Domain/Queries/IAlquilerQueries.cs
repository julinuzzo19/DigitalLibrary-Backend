using System.Collections.Generic;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Domain.Queries
{
    public interface IAlquilerQueries
    {
        List<Alquiler> GetAllAlquiler(int estado);
        Alquiler GetAlquilerById_Isbn(int clienteid, string isbn);
        List<Alquiler> GetLibrosByCliente(int id);
    }
}
