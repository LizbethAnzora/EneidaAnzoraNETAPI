using AuthApi.Entidades;
using AuthApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Repositorios
{
    public class CategoriaELRepository : ICategoriaELRepository
    {
        private readonly AppDbContext _context;
        public CategoriaELRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaEL>> ObtenerTodasAsync()
        {
            return await _context.CategoriasEL.ToListAsync();
        }

        public async Task<CategoriaEL> ObtenerPorIdAsync(int id)
        {
            return await _context.CategoriasEL.FindAsync(id);
        }

        public async Task<CategoriaEL> CrearAsync(CategoriaEL categoria)
        {
            _context.CategoriasEL.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> ActualizarAsync(CategoriaEL categoria)
        {
            _context.CategoriasEL.Update(categoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var categoria = await _context.CategoriasEL.FindAsync(id);
            if (categoria == null) return false;
            _context.CategoriasEL.Remove(categoria);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
