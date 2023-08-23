using MediatR;
using Permission.Domain.DTOs;
using Permission.Domain.Interfaces;
using Permission.Persistence.Queries;

namespace Permission.Application.Handlers;

public class GetAllPermissionHandler : IRequestHandler<GetAllPermissionQuery, IEnumerable<PermisosDto>?>
{
    private readonly IGetallPermissionRepository _repository;

    public GetAllPermissionHandler(IGetallPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PermisosDto>?> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllPermissionAsync();
    }
}