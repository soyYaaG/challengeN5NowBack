using MediatR;
using Microsoft.AspNetCore.Mvc;
using Permission.Domain.DTOs;
using Permission.Persistence.Commands;
using Permission.Persistence.Queries;

namespace Permission.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllPermissionTypes")]
    public async Task<ActionResult<IEnumerable<TipoPermisosDto>>> GetAll()
    {
        var all = await _mediator.Send(new GetAllPermissionTypesQuery());

        if (all == null)
            return NotFound();

        return Ok(all);
    }
}