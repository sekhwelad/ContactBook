using ContactBook.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.Infrastructure;

internal sealed class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));

        builder.HasKey(x => x.Id);

        builder.Property(profile => profile.FirstName)
                .HasMaxLength(200)
                .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(profile => profile.LastName)
          .HasMaxLength(200)
          .HasConversion(lastName => lastName.Value, value => new LastName(value));

    }
}
