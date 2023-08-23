using MediatR;
using Permission.Domain.DTOs;

namespace Permission.Persistence.Commands;

public record CreatePermissionCommand(string NombreEmpleado, string ApellidoEmpleado, int TipoPermiso) : IRequest<PermisosDto>;