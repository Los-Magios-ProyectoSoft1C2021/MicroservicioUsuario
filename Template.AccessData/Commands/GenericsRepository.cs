using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Commands;
using System.Threading.Tasks;

namespace Template.AccessData.Commands
{
    public class GenericsRepository:IGenericsRepository
    {
        private readonly UsuarioDbContext _context;
        public GenericsRepository (UsuarioDbContext context)
        {
            _context = context;
        }
        public async Task Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}