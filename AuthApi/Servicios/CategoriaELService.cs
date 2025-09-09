
using AuthApi.DTOs.CategoriaELDTOs;
using AuthApi.Entidades;
using AuthApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Servicios
{
	public class CategoriaELService : ICategoriaELService
	{
		private readonly ICategoriaELRepository _repo;
		public CategoriaELService(ICategoriaELRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<CategoriaELListDto>> ObtenerTodasAsync()
		{
			var categorias = await _repo.ObtenerTodasAsync();
			return categorias.Select(c => new CategoriaELListDto
			{
				Id = c.Id,
				Nombre = c.Nombre
			});
		}

		public async Task<CategoriaELDetailDto> ObtenerPorIdAsync(int id)
		{
			var c = await _repo.ObtenerPorIdAsync(id);
			if (c == null) return null;
			return new CategoriaELDetailDto
			{
				Id = c.Id,
				Nombre = c.Nombre,
				Descripcion = c.Descripcion
			};
		}

		public async Task<CategoriaELDetailDto> CrearAsync(CategoriaELCreateDto dto)
		{
			var categoria = new CategoriaEL
			{
				Nombre = dto.Nombre,
				Descripcion = dto.Descripcion
			};
			var creada = await _repo.CrearAsync(categoria);
			return new CategoriaELDetailDto
			{
				Id = creada.Id,
				Nombre = creada.Nombre,
				Descripcion = creada.Descripcion
			};
		}

		public async Task<bool> ActualizarAsync(CategoriaELUpdateDto dto)
		{
			var categoria = await _repo.ObtenerPorIdAsync(dto.Id);
			if (categoria == null) return false;
			categoria.Nombre = dto.Nombre;
			categoria.Descripcion = dto.Descripcion;
			return await _repo.ActualizarAsync(categoria);
		}

		public async Task<bool> EliminarAsync(int id)
		{
			return await _repo.EliminarAsync(id);
		}
	}
}
