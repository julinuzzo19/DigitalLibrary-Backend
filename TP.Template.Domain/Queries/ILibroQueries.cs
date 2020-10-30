using System.Collections.Generic;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Domain.Queries
{
    public interface ILibroQueries
    {
        Libro GetLibroById(string id);
        List<ResponseLibro> GetAllLibros(bool? stock, string autor, string titulo);

    }
}
