using Microsoft.EntityFrameworkCore;
using Permission.Domain.DTOs;
using Permission.Domain.Entities;
using Permission.Domain.Interfaces;

namespace Permission.Persistence.Repositories;

public class PermissionRepository : ICreatePermissionRepository, IGetallPermissionRepository, IGetallPermissionTypesRepository, IUpdatePermissionRepository
{
    private readonly DataContext _context;

    public PermissionRepository(DataContext context)
    {
        _context = context;
    }

    private PermisosDto GetPermission(Permisos permission)
    {
        if (permission.TipoPermisos == null)
            throw new NullReferenceException();

        return new PermisosDto
        {
            Id = permission.Id,
            ApellidoEmpleado = permission.ApellidoEmpleado,
            FechaPermiso = permission.FechaPermiso,
            NombreEmpleado = permission.NombreEmpleado,
            TipoPermisos = new TipoPermisosDto
            {
                Id = permission.TipoPermisos.Id,
                Descripcion = permission.TipoPermisos.Descripcion
            }
        };
    }

    public async Task<PermisosDto?> CreatePermissionAsync(Permisos permission)
    {
        _context.Permisos.Add(permission);
        await _context.SaveChangesAsync();

        var permissionItem = await _context.Permisos.Include(f => f.TipoPermisos).FirstAsync(p => p.Id == permission.Id);

        if (permissionItem == null)
            return null;

        return GetPermission(permissionItem);
    }

    public async Task<IEnumerable<PermisosDto>?> GetAllPermissionAsync()
    {
        var getAll = await _context.Permisos.Include(f => f.TipoPermisos).ToListAsync();

        if (getAll == null)
            return null;

        return getAll.Select(permission => GetPermission(permission));
    }

    public async Task<IEnumerable<TipoPermisosDto>?> GetAllPermissionTypesAsync()
    {
        var getAll = await _context.TipoPermisos.ToListAsync();

        if (getAll == null)
            return null;

        return getAll.Select(permission => new TipoPermisosDto
        {
            Id = permission.Id,
            Descripcion = permission.Descripcion
        });
    }

    public async Task<PermisosDto?> UpdatePermissionAsync(Permisos permission)
    {
        var permissionItem = await _context.Permisos.FindAsync(
            new object[] {
                permission.Id
            }
        );

        if (permissionItem == null)
            return null;
        
        permissionItem.NombreEmpleado = permission.NombreEmpleado;
        permissionItem.ApellidoEmpleado = permission.ApellidoEmpleado;
        permissionItem.TipoPermiso = permission.TipoPermiso;

        await _context.SaveChangesAsync();

        permissionItem = await _context.Permisos.Include(f => f.TipoPermisos).FirstAsync(p => p.Id == permission.Id);

        return GetPermission(permissionItem);
    }
}