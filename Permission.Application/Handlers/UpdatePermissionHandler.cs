using MediatR;
using Permission.Domain.DTOs;
using Permission.Domain.Entities;
using Permission.Domain.Interfaces;
using Permission.Persistence.Commands;

namespace Permission.Application.Handlers;

public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, PermisosDto?>
{
    private readonly IUpdatePermissionRepository _repository;

    public UpdatePermissionHandler(IUpdatePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<PermisosDto?> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var updatePermission = new Permisos
        {
            Id = request.Id,
            NombreEmpleado = request.NombreEmpleado,
            ApellidoEmpleado = request.ApellidoEmpleado,
            TipoPermiso = request.TipoPermiso
        };

        return await _repository.UpdatePermissionAsync(updatePermission);
    }
}