using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Domain.Queries
{
    public interface ILibroQueries
    {
        Libro GetLibroById(string id);
        List<ResponseLibro> GetAllLibros(int stock, string autor, string titulo);

    }
}
