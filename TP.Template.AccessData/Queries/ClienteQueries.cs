﻿using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TP2.Template.Domain.DTOs;
using TP2.Template.Domain.Entities;
using TP2.Template.Domain.Queries;

namespace TP2.Template.AccessData.Queries
{
    public class ClienteQueries : IClienteQueries
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public ClienteQueries(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ClienteResponse> GetAllClientes(string nombre, string apellido, string dni)
        {                     
            var db = new QueryFactory(connection, sqlKataCompiler);

            if (nombre==null && apellido==null && dni==null)
            {
                var query = db.Query("Cliente").From("Cliente");
                var result = query.Get<ClienteResponse>();
                return result.ToList();
            }
            if (nombre!=null)
            {

                var query = db.Query("Cliente").WhereRaw($"Nombre like '%{nombre}%'", "sql");    
                var result = query.Get<ClienteResponse>();
                return result.ToList();
            }
            if (apellido!=null)
            {

                var query = db.Query("Cliente").WhereRaw($"Apellido like '%{apellido}%'", "sql");
                var result = query.Get<ClienteResponse>();
                return result.ToList();
            }
            if (dni!=null)
            {
                var query = db.Query("Cliente").Where("Cliente.Dni", "=", dni);
                var result = query.Get<ClienteResponse>();
                return result.ToList();
            }
            return null;
                    
        }

        public ClienteDto GetClienteById(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var cliente = db.Query("Cliente").SelectRaw("*").From("Cliente").Where("Cliente.Id", "=", id).FirstOrDefault<ClienteDto>();
          
            return cliente;         
        }
    }
}
