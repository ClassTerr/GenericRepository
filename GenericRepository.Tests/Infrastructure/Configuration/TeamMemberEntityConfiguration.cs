using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericRepository.Tests.Infrastructure.Configuration;

public class TeamMemberEntityConfiguration : IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        builder
            .HasKey(pe => new { pe.TeamId, pe.MemberId });

        builder
            .HasOne(pe => pe.Team)
            .WithMany(p => p.TeamMembers)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(pe => pe.Member)
            .WithMany(p => p.TeamsMembership)
            .HasForeignKey(x => x.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
