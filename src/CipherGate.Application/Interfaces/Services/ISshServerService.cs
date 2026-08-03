using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;

namespace CipherGate.Application.Interfaces.Services;

public interface ISshServerService
{
    public Task<SshServerResponse> CreateAsync(SshServerCreateRequest request);

    public Task<SshServerResponse> GetByIdAsync(Guid id);

    public Task<IEnumerable<SshServerResponse>> GetAsync();

    public Task DeleteAsync(Guid id);

    public Task<SshServerResponse> UpdateAsync(Guid id, SshServerUpdateRequest request);
}
