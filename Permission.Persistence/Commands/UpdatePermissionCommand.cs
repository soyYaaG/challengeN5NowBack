using MediatR;
using Permission.Domain.DTOs;

namespace Permission.Persistence.Commands;

public record UpdatePermissionCommand(int Id, string NombreEmpleado, string ApellidoEmpleado, int TipoPermiso) : IRequest<PermisosDto>;