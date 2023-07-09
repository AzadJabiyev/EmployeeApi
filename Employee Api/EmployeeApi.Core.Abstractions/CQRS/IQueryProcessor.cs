namespace EmployeeApi.Core.Abstractions.CQRS;

public interface IQueryProcessor
{
    Task<TResult> Handle<TResult>(IQuery<TResult> query);
}
