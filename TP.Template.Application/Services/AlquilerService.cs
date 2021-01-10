using System;
using System.Collections.Generic;
using TP2.Template.Domain.Commands;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;
using TP2.Template.Domain.Queries;

namespace TP2.Template.Application.Services
{
    public interface IAlquilerService
    {
        AlquilerResponse CreateAlquiler(AlquilerDto alquiler);
        List<AlquilerResponse> GetAll(int estado);
        void UpdateById(UpdateAlquilerBody alquiler);
        List<AlquilerResponse> GetLibrosByCliente(int id);
    }

    public class AlquilerService : IAlquilerService
    {
        private readonly IGenericsRepository _repository;
        private readonly IAlquilerQueries _query;
        private readonly ILibroQueries _libroquery;

        public AlquilerService(IGenericsRepository repository, IAlquilerQueries query, ILibroQueries libroquery)
        {
            _repository = repository;
            _query = query;
            _libroquery = libroquery;
        }

        public AlquilerResponse CreateAlquiler(AlquilerDto alquiler)
        {
            Libro libro = _libroquery.GetLibroById(alquiler.ISBN);

            var entity = new Alquiler
            {
                ClienteId = alquiler.ClienteId,
                ISBN = alquiler.ISBN
            };

            if (string.IsNullOrWhiteSpace(alquiler.FechaAlquiler))//Es reserva
            {
                entity.FechaReserva = Convert.ToDateTime(alquiler.FechaReserva);
                entity.EstadoAlquilerId = 2;
                if (libro.Stock > 0)
                {
                    libro.Stock--;
                    _repository.Update<Libro>(libro);
                    _repository.Add<Alquiler>(entity);
                    _repository.SaveChanges();
                }
                else { throw new Exception(); }
            }

            if (string.IsNullOrWhiteSpace(alquiler.FechaReserva))//Es alquiler
            {
                entity.FechaAlquiler = Convert.ToDateTime(alquiler.FechaAlquiler).Date;
                entity.FechaDevolucion = Convert.ToDateTime(alquiler.FechaAlquiler).Date.AddDays(7);
                entity.EstadoAlquilerId = 1;
                if (libro.Stock > 0)
                {
                    libro.Stock--;
                    _repository.Update<Libro>(libro);
                    _repository.Add<Alquiler>(entity);
                    _repository.SaveChanges();
                }
                else { throw new Exception(); }
            }

            if (!string.IsNullOrWhiteSpace(alquiler.FechaReserva) && !string.IsNullOrWhiteSpace(alquiler.FechaAlquiler))
            {
                throw new Exception();
            }

            return new AlquilerResponse
            {
                Id = entity.Id,
                FechaAlquiler = entity.FechaAlquiler.ToString(),
                FechaReserva = entity.ToString(),
                FechaDevolucion = entity.ToString(),
                ClienteId = entity.ClienteId,
                LibroISBN = entity.ISBN,
                Imagen=libro.Imagen
                

            };
        }

        public List<AlquilerResponse> GetAll(int estado)
        {
            List<Alquiler> alquileres = _query.GetAllAlquiler(estado);
            List<AlquilerResponse> alql = new List<AlquilerResponse>() { };

            foreach (Alquiler item in alquileres)
            {
                Libro libro = _libroquery.GetLibroById(item.ISBN);

                AlquilerResponse alr = new AlquilerResponse
                {
                    Id = item.Id,
                    FechaAlquiler = item.FechaAlquiler.ToString(),
                    FechaDevolucion = item.FechaDevolucion.ToString(),
                    FechaReserva = item.FechaReserva.ToString(),
                    ClienteId = item.ClienteId,
                    LibroISBN = item.ISBN,
                    Titulo = libro.Titulo,
                    Autor = libro.Autor,
                    Editorial = libro.Editorial,
                    Stock = (int)libro.Stock,
                    Imagen=libro.Imagen
                
                };
                alql.Add(alr);
            }
            return alql;
        }

        public void UpdateById(UpdateAlquilerBody alquiler)
        {


            Alquiler alq = _query.GetAlquilerById_Isbn(alquiler.ClienteId, alquiler.ISBN);
            if (alq.EstadoAlquilerId == 2)
            {
                alq.EstadoAlquilerId = 1;
                alq.FechaAlquiler = DateTime.Now;
                alq.FechaDevolucion = ((DateTime)alq.FechaAlquiler).AddDays(7);

                _repository.Update<Alquiler>(alq);
                _repository.SaveChanges();
            }
            else
            {
                throw new Exception();
            }

        }

        public List<AlquilerResponse> GetLibrosByCliente(int id)
        {
            List<Alquiler> alquileres = _query.GetLibrosByCliente(id);

            List<AlquilerResponse> alql = new List<AlquilerResponse>() { };

            if (id > 0)
            {
                foreach (Alquiler item in alquileres)
                {
                    Libro libro = _libroquery.GetLibroById(item.ISBN);

                    AlquilerResponse alr = new AlquilerResponse
                    {
                        Id = item.Id,
                        FechaAlquiler = item.FechaAlquiler.ToString(),
                        FechaDevolucion = item.FechaDevolucion.ToString(),
                        FechaReserva = item.FechaReserva.ToString(),
                        ClienteId = item.ClienteId,
                        LibroISBN = item.ISBN,
                        Titulo = libro.Titulo,
                        Autor = libro.Autor,
                        Editorial = libro.Editorial,
                        Stock = (int)libro.Stock,
                        Imagen=libro.Imagen
                    };
                    alql.Add(alr);
                }
                return alql;
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
