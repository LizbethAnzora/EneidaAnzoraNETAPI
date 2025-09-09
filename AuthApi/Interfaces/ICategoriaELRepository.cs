using AuthApi.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Interfaces
{
    public interface ICategoriaELRepository
    {
        Task<IEnumerable<CategoriaEL>> ObtenerTodasAsync();
        Task<CategoriaEL> ObtenerPorIdAsync(int id);
        Task<CategoriaEL> CrearAsync(CategoriaEL categoria);
        Task<bool> ActualizarAsync(CategoriaEL categoria);
        Task<bool> EliminarAsync(int id);
    }
}
