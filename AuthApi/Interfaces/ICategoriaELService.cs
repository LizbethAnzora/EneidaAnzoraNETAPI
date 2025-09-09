using AuthApi.DTOs.CategoriaELDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApi.Interfaces
{
    public interface ICategoriaELService
    {
        Task<IEnumerable<CategoriaELListDto>> ObtenerTodasAsync();
        Task<CategoriaELDetailDto> ObtenerPorIdAsync(int id);
        Task<CategoriaELDetailDto> CrearAsync(CategoriaELCreateDto dto);
        Task<bool> ActualizarAsync(CategoriaELUpdateDto dto);
        Task<bool> EliminarAsync(int id);
    }
}
