using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;

namespace CipherGate.Application.Interfaces.Services;

public interface IUserService
{
    public Task<UserResponse> CreateAsync(UserCreateRequest request);

    public Task<UserResponse> GetByIdAsync(Guid id);

    public Task<IEnumerable<UserResponse>> GetAsync();

    public Task DeleteAsync(Guid id);

    public Task<UserResponse> UpdateAsync(Guid id, UserUpdateRequest request);
}
