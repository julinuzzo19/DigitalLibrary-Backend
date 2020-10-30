using SqlKata.Compilers;
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
    public class LibroQueries : ILibroQueries
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public LibroQueries(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseLibro> GetAllLibros(int stock, string autor, string titulo)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            if (stock==0 && autor==null && titulo==null)
            {
                var query = db.Query("Libro");
                var result = query.Get<ResponseLibro>();
                return result.ToList();
            }

            if (stock!=0)
            {
                var query = db.Query("Libro").Where("Libro.Stock","=",stock);                              
                var result = query.Get<ResponseLibro>();
                return result.ToList();
            }

            if (autor!=null)
            {
                var query = db.Query("Libro").WhereRaw($"Autor like '%{autor}%'", "sql");
                var result = query.Get<ResponseLibro>();
                return result.ToList();
            }

            if (titulo!=null)
            {
                var query = db.Query("Libro").WhereRaw($"Titulo like '%{titulo}%'", "sql");
                var result = query.Get<ResponseLibro>();
                return result.ToList();
            }

            return null;
        }

        public Libro GetLibroById(string id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var libro = db.Query("Libro").Where("ISBN", "=", id).FirstOrDefault<Libro>();
            
                return libro;           
        }
    }
}
