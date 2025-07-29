namespace ContactBook.Domain.Abstractions;

public interface IUnitOfwork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}