namespace EmployeeApi.Core.Abstractions.CQRS;

public interface ICommandProcessor
{
    Task Handle(ICommand command);
}