namespace EmployeeApi.Core.Abstractions.CQRS;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command);
}
