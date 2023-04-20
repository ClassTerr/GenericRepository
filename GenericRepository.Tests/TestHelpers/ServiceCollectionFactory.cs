using AutoMapper;
using GenericRepository.Common.Common;
using GenericRepository.Common.Contracts;
using GenericRepository.Common.Contracts.ExceptionFactories;
using GenericRepository.Common.Contracts.Services.Common;
using GenericRepository.Common.Exceptions.Factories;
using GenericRepository.Extensions;
using GenericRepository.Repositories.CrudBase;
using GenericRepository.Services.Common;
using GenericRepository.Tests.BLL.Contracts.Models;
using GenericRepository.Tests.BLL.Contracts.Repositories;
using GenericRepository.Tests.BLL.Contracts.UnitsOfWork;
using GenericRepository.Tests.Infrastructure;
using GenericRepository.Tests.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace GenericRepository.Tests.TestHelpers;

public static class ServiceCollectionFactory
{
    public static ServiceCollection CreateServiceCollection()
    {
        var services = new ServiceCollection();

        // Common services

        // Repositories
        services.AddSingleton<ICompanyRepository, CompanyRepository>();
        services.AddSingleton<IDepartmentRepository, DepartmentRepository>();


        services.AddSingleton(DatabaseInitializer.GetMemoryContext());
        services.AddTransient(typeof(RepositoryCommonDependencies<>));

        // Common services
        services.AddSingleton<IEntityAuditService, EntityAuditService>();
        services.AddSingleton<IAggregateUnitOfWork, AggregateUnitOfWork>();
        services.AddUnitOfWork<ITestsUnitOfWork, TestsUnitOfWork>(ServiceLifetime.Singleton);
        services.AddSingleton<IDateTime, MachineDateTimeService>();
        services.AddSingleton(typeof(IRepositoryExceptionFactory<>), typeof(RepositoryExceptionFactory<>));
        services.AddLogging();

        var iCurrentUserServiceMock = new Mock<ICurrentUserService>();

        iCurrentUserServiceMock.Setup(x => x.GetUserAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new TestUser(Guid.Parse("AD82469C-F0DA-4583-96A4-88F148807CA9"), "Test user", new()));

        services.AddSingleton(iCurrentUserServiceMock.Object);
        services.AddSingleton(iCurrentUserServiceMock);

        // Mapper
        services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(_ => { }))); // TODO

        return services;
    }
}
