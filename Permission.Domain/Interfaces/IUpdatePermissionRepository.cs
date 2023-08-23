using Permission.Domain.DTOs;
using Permission.Domain.Entities;

namespace Permission.Domain.Interfaces;

public interface IUpdatePermissionRepository
{
    Task<PermisosDto?> UpdatePermissionAsync(Permisos permission);
}