using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Tests.Infrastructure;

public class TestsDbContext : GenericRepositoryContextBase<TestsDbContext>
{
    public TestsDbContext(DbContextOptions<TestsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<TeamMember> TeamsMembers { get; set; } = null!;
}
