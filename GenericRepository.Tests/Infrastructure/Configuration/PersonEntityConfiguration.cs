using GenericRepository.Common.Constants;
using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericRepository.Tests.Infrastructure.Configuration;

public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();
    }
}
