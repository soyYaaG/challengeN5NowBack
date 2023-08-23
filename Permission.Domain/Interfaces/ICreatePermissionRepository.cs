using Permission.Domain.DTOs;
using Permission.Domain.Entities;

namespace Permission.Domain.Interfaces;

public interface ICreatePermissionRepository
{
    Task<PermisosDto?> CreatePermissionAsync(Permisos permission);
}