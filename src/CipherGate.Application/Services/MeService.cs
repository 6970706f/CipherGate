using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;
using CipherGate.Application.Interfaces.Repositories;
using CipherGate.Application.Interfaces.Services;
using CipherGate.Domain.Entities;

namespace CipherGate.Application.Services;

public sealed class MeService(
    IUserRepository userRepository
) : IMeService
{
    public async Task<MeResponse> CreateAsync(MeCreateRequest request)
    {
        var user = new User(
            request.Name,
            request.Email,
            request.Password
        );

        await userRepository.SaveChangesAsync();

        return ToDTO(user);
    }

    public async Task<MeResponse> GetByIdAsync(Guid id)
    {
        var user = await GetOrNotFoundAsync(id);

        return ToDTO(user);
    }

    public async Task<IEnumerable<MeResponse>> GetAsync()
    {
        var users = await userRepository.GetAsync();

        return users.Select(ToDTO);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetOrNotFoundAsync(id);

        userRepository.Delete(user);
        await userRepository.SaveChangesAsync();
    }

    public async Task<MeResponse> UpdateAsync(Guid id, MeUpdateRequest request)
    {
        var user = await GetOrNotFoundAsync(id);

        user.ChangeName(request.Name);

        await userRepository.SaveChangesAsync();
    
        return ToDTO(user);
    }

    private async Task<User> GetOrNotFoundAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id)
            ?? throw new Exception();
        
        return user;
    }

    private MeResponse ToDTO(User user)
    {
        return new MeResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            ModifiedAt = user.ModifiedAt
        };
    }
}
