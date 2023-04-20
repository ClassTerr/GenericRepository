using GenericRepository.Common.Constants;
using GenericRepository.Tests.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericRepository.Tests.Infrastructure.Configuration;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(StringPropertyLengthConstants.Name)
            .IsRequired();

        builder
            .HasOne(x => x.Company)
            .WithMany(p => p.Departments)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.HeadOfDepartment)
            .WithMany(p => p.DepartmentsUnderManagement)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
