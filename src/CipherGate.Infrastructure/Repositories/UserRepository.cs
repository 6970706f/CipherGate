using CipherGate.Application.Interfaces.Repositories;
using CipherGate.Domain.Entities;
using CipherGate.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CipherGate.Infrastructure.Repositories;

public sealed class UserRepository(
    AppDbContext context
) : IUserRepository
{
    public async Task CreateAsync(User user)
        => await context.Users.AddAsync(user);
    
    public async Task<User?> GetByIdAsync(Guid id)
        => await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    
    public async Task<IEnumerable<User>> GetAsync()
        => await context.Users.ToListAsync();
    
    public void Delete(User user)
        => context.Users.Remove(user);
    
    public async Task SaveChangesAsync()
        => await context.SaveChangesAsync();
}
