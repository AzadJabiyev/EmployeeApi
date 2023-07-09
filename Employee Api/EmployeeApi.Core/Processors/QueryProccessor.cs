using EmployeeApi.Core.Abstractions.CQRS;

namespace EmployeeApi.Core.Processors;

public sealed class QueryProcessor : IQueryProcessor
{
    private readonly IServiceProvider _serviceProvider;

    public QueryProcessor(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResult> Handle<TResult>(IQuery<TResult> query)
    {
        var handlerType = typeof(IQueryHandler<,>)
            .MakeGenericType(query.GetType(), typeof(TResult));

        dynamic handler = _serviceProvider.GetService(handlerType);

        return handler.Handle((dynamic)query);
    }
}
