using Permission.Domain.DTOs;

namespace Permission.Domain.Interfaces;

public interface IGetallPermissionTypesRepository
{
    Task<IEnumerable<TipoPermisosDto>?> GetAllPermissionTypesAsync();
}