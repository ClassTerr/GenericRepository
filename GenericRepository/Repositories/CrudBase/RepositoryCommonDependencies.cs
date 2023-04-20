using AutoMapper;
using GenericRepository.Common.Contracts.ExceptionFactories;
using Microsoft.Extensions.Logging;

namespace GenericRepository.Repositories.CrudBase;

/// <summary>
/// An aggregated container to carry all necessary dependencies for EntityCrudService.
/// </summary>
/// <param name="Mapper">The automapper used to convert types.</param>
/// <param name="LoggerFactory">The logger factory.</param>
/// <param name="ExceptionFactory">The exception factory.</param>
public record RepositoryCommonDependencies<TEntity>(
    IMapper Mapper,
    ILoggerFactory LoggerFactory,
    IRepositoryExceptionFactory<TEntity> ExceptionFactory);
