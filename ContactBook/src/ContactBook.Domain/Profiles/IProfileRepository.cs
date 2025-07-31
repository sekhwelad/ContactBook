namespace ContactBook.Domain.Persons;

public interface IProfileRepository
{
    Task<Profile> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Profile> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    void Add(Profile profile);
}


