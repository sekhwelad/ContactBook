namespace ContactBook.Domain.Persons;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
