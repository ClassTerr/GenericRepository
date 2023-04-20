using GenericRepository.Common.Contracts;

namespace GenericRepository.Services.Common
{
    /// <inheritdoc />
    /// <remarks>Be aware there is no distributed lock mechanism here. All units of work are saved sequentially, so you need to
    /// provide your own mechanism for rolling back changes if some of units were committed by the time error occured.</remarks>
    public class AggregateUnitOfWork : IAggregateUnitOfWork
    {
        private readonly List<IUnitOfWork> _unitsOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateUnitOfWork" /> class.
        /// </summary>
        /// <param name="unitsOfWork">All of the registered unit of works.</param>
        public AggregateUnitOfWork(IEnumerable<IUnitOfWork> unitsOfWork)
        {
            _unitsOfWork = unitsOfWork.Where(x => x.GetType() != typeof(AggregateUnitOfWork)).ToList();
        }

        /// <inheritdoc />
        public async Task SaveChangesAsync(CancellationToken token = default)
        {
            foreach (var unitOfWork in _unitsOfWork)
            {
                await unitOfWork.SaveChangesAsync(token);
            }
        }

        /// <inheritdoc />
        public void Rollback()
        {
            foreach (var unitOfWork in _unitsOfWork)
            {
                unitOfWork.Rollback();
            }
        }
    }
}
