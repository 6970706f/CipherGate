using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;
using CipherGate.Application.Interfaces.Repositories;
using CipherGate.Application.Interfaces.Services;
using CipherGate.Domain.Entities;

namespace CipherGate.Application.Services;

public class UserService(
    IUserRepository userRepository
) : IUserService
{
    public async Task<UserResponse> CreateAsync(UserCreateRequest request)
    {
        var user = new User(
            request.Name,
            request.Email,
            request.Password
        );

        await userRepository.CreateAsync(user);
        await userRepository.SaveChangesAsync();

        return ToDTO(user);
    }

    public async Task<UserResponse> GetByIdAsync(Guid id)
    {
        return ToDTO(await GetOrNotFoundAsync(id));
    }

    public async Task<IEnumerable<UserResponse>> GetAsync()
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

    public async Task<UserResponse> UpdateAsync(Guid id, UserUpdateRequest request)
    {
        var user = await GetOrNotFoundAsync(id);

        user.ChangeName(request.Name);
        user.ChangeEmail(request.Email);
        user.ChangePassword(request.Password);
        user.ChangeRole(request.Role);

        await userRepository.SaveChangesAsync();

        return ToDTO(user);
    }

    private async Task<User> GetOrNotFoundAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id)
            ?? throw new Exception();
        
        return user;
    }

    private UserResponse ToDTO(User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }
}
