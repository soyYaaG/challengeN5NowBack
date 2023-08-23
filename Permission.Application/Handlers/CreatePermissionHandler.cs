using MediatR;
using Permission.Domain.DTOs;
using Permission.Domain.Entities;
using Permission.Domain.Interfaces;
using Permission.Persistence.Commands;

namespace Permission.Application.Handlers;

public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, PermisosDto?>
{
    private readonly ICreatePermissionRepository _repository;

    public CreatePermissionHandler(ICreatePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<PermisosDto?> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var createPermission = new Permisos
        {
            NombreEmpleado = request.NombreEmpleado,
            ApellidoEmpleado = request.ApellidoEmpleado,
            TipoPermiso = request.TipoPermiso
        };

        return await _repository.CreatePermissionAsync(createPermission);
    }
}