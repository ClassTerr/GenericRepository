using GenericRepository.Common.Common;
using System.Linq.Expressions;

namespace GenericRepository.Tests.Infrastructure.Entities;

public record PkTeamMember(int TeamId, int MemberId) : IEntityCompositePrimaryKey<TeamMember>
{
    public Expression<Func<TeamMember, bool>> GetFilterById()
    {
        return x => x.TeamId == TeamId && x.MemberId == MemberId;
    }
}
