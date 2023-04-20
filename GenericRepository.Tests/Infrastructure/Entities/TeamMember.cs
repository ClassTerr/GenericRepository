using GenericRepository.Common.Common;

namespace GenericRepository.Tests.Infrastructure.Entities;

public class TeamMember : BaseAuditableEntity<PkTeamMember>
{
    public int TeamId { get; set; }

    public int MemberId { get; set; }

    public Team Team { get; set; } = default!;

    public Person Member { get; set; } = default!;

    public override PkTeamMember Id
    {
        get => new(TeamId, MemberId);
        set => (TeamId, MemberId) = value;
    }
}
