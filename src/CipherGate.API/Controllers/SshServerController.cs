using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;
using CipherGate.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CipherGate.API.Controllers;

[ApiController]
[Route("servers")]
public class SshServerController(
    ISshServerService serverService
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SshServerResponse>>> Get()
    {
        var servers = await serverService.GetAsync();

        return Ok(servers);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<SshServerResponse>> GetById(Guid id)
    {
        var server = await serverService.GetByIdAsync(id);

        return Ok(server);
    }

    [HttpPost]
    public async Task<ActionResult<SshServerResponse>> Create(SshServerCreateRequest request)
    {
        var server = await serverService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = server.Id},
            server
        );
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serverService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPatch("{id:Guid}")]
    public async Task<ActionResult<SshServerResponse>> Update(Guid id, SshServerUpdateRequest request)
    {
        var server = await serverService.UpdateAsync(id, request);

        return Ok(server);
    }
}
