using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP2.Template.Domain.Entities;
using TP2.Template.Domain.Queries;

namespace TP2.Template.AccessData.Queries
{
    public class AlquilerQueries : IAlquilerQueries
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public AlquilerQueries(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<Alquiler> GetAllAlquiler(int estado)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            if (estado == 0)
            {
                var query = db.Query("Alquiler");

                var result = query.Get<Alquiler>();

                return result.ToList();
            }

            if (estado == 1)
            {
                var query = db.Query("Alquiler").Where("EstadoAlquilerId", "=", estado);

                var result = query.Get<Alquiler>();

                return result.ToList();
            }

            if (estado == 2)
            {
                var query = db.Query("Alquiler").Where("EstadoAlquilerId", "=", estado);

                var result = query.Get<Alquiler>();

                return result.ToList();
            }
            if (estado == 3)
            {
                var query = db.Query("Alquiler").Where("EstadoAlquilerId", "=", estado);

                var result = query.Get<Alquiler>();

                return result.ToList();
            }

            else { return null; }

        }

<<<<<<< HEAD

=======
       
>>>>>>> 861c0524c3bdc6fdb1fa95f4959247cc89fd535e


        public Alquiler GetAlquilerById_Isbn(int clienteid, string isbn)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var alquiler = db.Query("Alquiler").Where(new
            {
                ISBN = isbn,
                ClienteId = clienteid

            }).FirstOrDefault<Alquiler>();

            return alquiler;
        }

        public List<Alquiler> GetLibrosByCliente(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Alquiler").Where("ClienteId", "=", id);

            var result = query.Get<Alquiler>();

            return result.ToList();
        }

    }
}
