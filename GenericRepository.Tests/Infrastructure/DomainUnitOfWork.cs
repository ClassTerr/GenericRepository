using GenericRepository.Common.Contracts.Services.Common;
using GenericRepository.Services.Common;
using GenericRepository.Tests.BLL.Contracts.UnitsOfWork;

namespace GenericRepository.Tests.Infrastructure
{
    public class TestsUnitOfWork : UnitOfWork<TestsDbContext>, ITestsUnitOfWork
    {
        public TestsUnitOfWork(TestsDbContext context,
            IEntityAuditService entityAuditService,
            ICurrentUserService currentUserService) : base(
            context,
            entityAuditService,
            currentUserService) { }
    }
}
