namespace GenericRepository.Models;

public class RepositoryMappingService<TEntity> where TEntity : class
{
    public required RepositoryMappingContext<TEntity> CreateContext { get; set; }
    public required RepositoryMappingContext<TEntity> UpdateContext { get; set; }
}
