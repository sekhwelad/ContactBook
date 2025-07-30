using ContactBook.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.Infrastructure.Configurations;

internal sealed class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));

        builder.HasKey(x => x.Id);

        builder.Property(profile => profile.FirstName)
                .HasMaxLength(200);

        builder.Property(profile => profile.LastName)
          .HasMaxLength(200);

    }
}
