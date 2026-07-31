using CipherGate.Domain.Entities;

namespace CipherGate.Application.Interfaces.Repositories;

public interface ISshServerRepository
{
    public Task CreateAsync(SshServer server);

    public Task<SshServer?> GetByIdAsync(Guid id);

    public Task<IEnumerable<SshServer>> GetAsync();

    public void Delete(SshServer server);

    public Task SaveChangesAsync();
}
