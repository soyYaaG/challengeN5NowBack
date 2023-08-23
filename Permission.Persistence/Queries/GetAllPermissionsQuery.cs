using MediatR;
using Permission.Domain.DTOs;

namespace Permission.Persistence.Queries;

public record GetAllPermissionQuery : IRequest<IEnumerable<PermisosDto>>;