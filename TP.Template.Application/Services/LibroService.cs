using System.Collections.Generic;
using TP2.Template.Domain.Commands;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;
using TP2.Template.Domain.Queries;

namespace TP2.Template.Application.Services
{
    public interface ILibroService
    {
        ResponseLibro CreateLibro(LibroDto libro);
        List<ResponseLibro> GetAllLibros(int stock, string autor, string titulo);
        ResponseLibro GetLibroById(string id);
    }
    public class LibroService:ILibroService
    {
        private readonly IGenericsRepository _repository;
        private readonly ILibroQueries _query;

        public LibroService(IGenericsRepository repository, ILibroQueries query)
        {
            _repository = repository;
            _query = query;
        }

        public ResponseLibro CreateLibro(LibroDto libro)
        {
            var entity = new Libro
            {
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                Editorial = libro.Editorial,
                Stock = libro.Stock,
                Imagen = libro.Imagen
            };
            _repository.Add<Libro>(entity);
            _repository.SaveChanges();
            return new ResponseLibro 
            {
                ISBN=entity.ISBN,
                Titulo=entity.Titulo,
                Autor=entity.Autor,
                Editorial=entity.Editorial,
                Stock=(int)entity.Stock,
                Imagen=entity.Imagen          
            };
        }
        public List<ResponseLibro> GetAllLibros(int stock, string autor,string titulo)
        {
           return _query.GetAllLibros(stock,autor,titulo);
        }

        public ResponseLibro GetLibroById(string id)
        {
            Libro libro = _query.GetLibroById(id);

            return new ResponseLibro 
            {
               ISBN=libro.ISBN,
               Titulo=libro.Titulo,
               Autor=libro.Autor,
               Editorial=libro.Editorial,
               Stock=(int)libro.Stock,
               Imagen=libro.Imagen
            };
        }
    }
}
