using TP2.Template.Domain.Commands;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;

namespace TP2.Template.Application.Services
{
    public class EstadoAlquilerService
    {
        private readonly IGenericsRepository _repository;

        public EstadoAlquilerService(IGenericsRepository repository)
        {
            _repository = repository;
        }

        public EstadoAlquiler CreateEstadoAlquiler(EstadoAlquilerDto estado)
        {
            var entity = new EstadoAlquiler
            {
                Descripcion = estado.Descripcion
            };
            _repository.Add<EstadoAlquiler>(entity);
            _repository.SaveChanges();
            return entity;
        }
    }
}
