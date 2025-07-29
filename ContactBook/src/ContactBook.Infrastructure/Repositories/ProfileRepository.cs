using ContactBook.Domain.Persons;

namespace AddressBook.Infrastructure.Repositories;

internal sealed class ProfileRepository : Repository<Profile>, IProfileRepository
{
    public ProfileRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        
    }
}
