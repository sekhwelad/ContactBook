using ContactBook.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfwork
{
    public ApplicationDbContext(DbContextOptions options)
          : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

}