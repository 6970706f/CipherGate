using CipherGate.Application.Interfaces.Repositories;
using CipherGate.Domain.Entities;
using CipherGate.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CipherGate.Infrastructure.Repositories;

public class SshServerRepository(
    AppDbContext context
) : ISshServerRepository
{
    public async Task CreateAsync(SshServer server)
        => await context.SshServers.AddAsync(server);
    
    public async Task<SshServer?> GetByIdAsync(Guid id)
        => await context.SshServers.FirstOrDefaultAsync(s => s.Id == id);
    
    public async Task<IEnumerable<SshServer>> GetAsync()
        => await context.SshServers.ToListAsync();
    
    public void Delete(SshServer server)
        => context.SshServers.Remove(server);
    
    public async Task SaveChangesAsync()
        => await context.SaveChangesAsync();
}
