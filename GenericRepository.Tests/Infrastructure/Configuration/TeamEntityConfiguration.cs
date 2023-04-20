using GenericRepository.Common.Constants;
using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericRepository.Tests.Infrastructure.Configuration;

public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();

        builder
            .HasOne(x => x.Manager)
            .WithMany(p => p.TeamsUnderManagement)
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
