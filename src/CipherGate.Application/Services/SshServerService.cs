using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;
using CipherGate.Application.Interfaces.Repositories;
using CipherGate.Application.Interfaces.Services;
using CipherGate.Domain.Entities;

namespace CipherGate.Application.Services;

public sealed class SshServerService(
    ISshServerRepository serverRepository
) : ISshServerService
{
    public async Task<SshServerResponse> CreateAsync(SshServerCreateRequest request)
    {
        var server = new SshServer(
            request.UserId,
            request.Name,
            request.Host,
            request.Port,
            request.Username,
            request.PrivateKey
        );

        await serverRepository.CreateAsync(server);
        await serverRepository.SaveChangesAsync();

        return ToDTO(server);
    }

    public async Task<SshServerResponse> GetByIdAsync(Guid id)
    {
        var server = await GetOrNotFoundAsync(id);

        return ToDTO(server);
    }

    public async Task<IEnumerable<SshServerResponse>> GetAsync()
    {
        var servers = await serverRepository.GetAsync();

        return servers.Select(ToDTO);
    }

    public async Task DeleteAsync(Guid id)
    {
        var server = await GetOrNotFoundAsync(id);

        serverRepository.Delete(server);
        await serverRepository.SaveChangesAsync();
    }

    public async Task<SshServerResponse> UpdateAsync(Guid id, SshServerUpdateRequest request)
    {
        var server = await GetOrNotFoundAsync(id);

        server.ChangeName(request.Name);
        server.ChangeHost(request.Host);
        server.ChangePort(request.Port);
        server.ChangeUsername(request.Username);
        server.ChangePrivateKey(request.PrivateKey);

        await serverRepository.SaveChangesAsync();

        return ToDTO(server);
    }

    private SshServerResponse ToDTO(SshServer server)
    {
        return new SshServerResponse
        {
            Id = server.Id,
            UserId = server.UserId,
            Name = server.Name,
            Host = server.Host,
            Port = server.Port,
            Username = server.Username,
            PrivateKey = server.PrivateKey
        };
    }

    private async Task<SshServer> GetOrNotFoundAsync(Guid id)
    {
        var server = await serverRepository.GetByIdAsync(id)
            ?? throw new Exception();
        
        return server;
    }
}
