using GestionTareas.Application.Dtos;

namespace GestionTareas.Application.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<TareaDto>> ListarAsync(int? categoriaId = null);
        Task<int> CrearAsync(CreateTareaRequest request);
    }
}
