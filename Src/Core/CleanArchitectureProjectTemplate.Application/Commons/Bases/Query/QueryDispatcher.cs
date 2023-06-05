using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureProjectTemplate.Application.Commons.Bases.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery where TResult : IQueryResult
        {
            object handler = _serviceProvider.GetRequiredService(typeof(IQueryHandler<TQuery, TResult>));

            return await ((IQueryHandler<TQuery, TResult>)handler).HandleAsync(query, cancellationToken);
        }
    }

}
