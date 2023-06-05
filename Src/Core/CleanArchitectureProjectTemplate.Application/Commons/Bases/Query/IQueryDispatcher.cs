namespace CleanArchitectureProjectTemplate.Application.Commons.Bases.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery where TResult : IQueryResult;
    }
}
