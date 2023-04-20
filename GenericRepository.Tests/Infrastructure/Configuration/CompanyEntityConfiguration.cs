using GenericRepository.Common.Constants;
using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericRepository.Tests.Infrastructure.Configuration;

public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();

        builder.Property(x => x.FoundedLocation)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();

        builder.Property(x => x.Industry)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();
    }
}
