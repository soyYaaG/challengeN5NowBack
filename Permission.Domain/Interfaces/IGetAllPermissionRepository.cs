using Permission.Domain.DTOs;

namespace Permission.Domain.Interfaces;

public interface IGetallPermissionRepository
{
    Task<IEnumerable<PermisosDto>?> GetAllPermissionAsync();
}