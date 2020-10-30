using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.Commands;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;
using TP2.Template.Domain.Queries;

namespace TP2.Template.Application.Services
{
    public interface IClienteService
    {
        ClienteResponse CreateCliente(ClienteDto cliente);
        public List<ClienteResponse> GetAll(string nombre,string apellido,string dni);
        public ClienteDto GetById(int id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IGenericsRepository _repository;
        private readonly IClienteQueries _query;

        public ClienteService(IGenericsRepository repository, IClienteQueries query)
        {
            _repository = repository;
            _query = query;
        }

        public ClienteResponse CreateCliente(ClienteDto cliente)
        {
            var entity = new Cliente
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Dni = cliente.Dni,
                Email = cliente.Email
            };

            _repository.Add<Cliente>(entity);
            _repository.SaveChanges();
            return new ClienteResponse
            { 
               Id=entity.Id,
                Nombre= entity.Nombre,
                Apellido= entity.Apellido,
                Email= entity.Email,
                Dni=entity.Dni
                
            };
        }     

        public List<ClienteResponse> GetAll(string nombre, string apellido, string dni)
        {
            return _query.GetAllClientes(nombre,apellido,dni);
        }

        public ClienteDto GetById(int id)
        {
            return _query.GetClienteById(id);
        }
    }
}
