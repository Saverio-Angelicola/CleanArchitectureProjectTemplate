namespace CleanArchitectureProjectTemplate.Application.Commons.Bases.Query
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery where TResult : IQueryResult
    {
        public Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }

}
