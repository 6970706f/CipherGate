using CipherGate.Domain.Entities;

namespace CipherGate.Application.Interfaces.Repositories;

public interface IUserRepository
{
    public Task CreateAsync(User user);

    public Task<User?> GetByIdAsync(Guid id);

    public Task<IEnumerable<User>> GetAsync();

    public void Delete(User user);

    public Task SaveChangesAsync();
}
