namespace GenericRepository.Common.Contracts
{
    /// <summary>
    /// Represents an aggregate unit of work. It will automatically save or rollback all or the registered <see cref="IUnitOfWork" />.
    /// </summary>
    public interface IAggregateUnitOfWork : IUnitOfWork { }
}
