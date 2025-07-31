using ContactBook.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.Repositories;

internal sealed class ProfileRepository : Repository<Profile>, IProfileRepository
{
    public ProfileRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        
    }

    public async Task<Profile?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<Profile>()
            .Where(p => p.Email == email)
            .FirstOrDefaultAsync();
    }

  
}
