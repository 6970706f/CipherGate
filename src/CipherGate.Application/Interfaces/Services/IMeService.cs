using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;

namespace CipherGate.Application.Interfaces.Services;

public interface IMeService
{
    public Task<MeResponse> CreateAsync(MeCreateRequest request);

    public Task<MeResponse> GetByIdAsync(Guid id);

    public Task<IEnumerable<MeResponse>> GetAsync();

    public Task DeleteAsync(Guid id);

    public Task<MeResponse> UpdateAsync(Guid id, MeUpdateRequest request);
}
