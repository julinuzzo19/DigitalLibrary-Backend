using System;
using System.Collections.Generic;
using System.Text;
using TP2.Template.Domain.Commands;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TP.Template.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly BibliotecaContext _context;

        public GenericsRepository(BibliotecaContext bibliotecaContext)
        {
            _context = bibliotecaContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            throw new Exception();          
        }    

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;                     
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
