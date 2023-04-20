using GenericRepository.Common.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GenericRepository.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddUnitOfWork<TInterface, TImplementation>(this IServiceCollection services,
            ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TInterface : class, IUnitOfWork where TImplementation : class, TInterface
        {
            services.Add(new(typeof(IUnitOfWork), typeof(TImplementation), lifetime));
            services.Add(new(typeof(TInterface), typeof(TImplementation), lifetime));

            return services;
        }
    }
}
