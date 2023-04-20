using GenericRepository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GenericRepository;

public abstract class GenericRepositoryContextBase<TContext> : DbContext where TContext : DbContext
{
    protected GenericRepositoryContextBase(DbContextOptions<TContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.IgnoreCompositePrimaryKeys();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TContext).Assembly); // TODO: customize

        modelBuilder.SetDefaultDateTimeKind(DateTimeKind.Utc);
        modelBuilder.DefaultValueForAutoAuditDates();
    }

    // TODO: delete after Microsoft will add support DateOnly?
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }

    /// <summary>
    /// Converts <see cref="DateOnly" /> to <see cref="DateTime" /> and vice versa.
    /// </summary>
    private class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)) { }
    }
}
