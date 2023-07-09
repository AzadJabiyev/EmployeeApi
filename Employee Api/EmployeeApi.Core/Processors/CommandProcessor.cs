using EmployeeApi.Core.Abstractions.CQRS;

namespace EmployeeApi.Core.Processors;

public class CommandProcessor : ICommandProcessor
{
    private IServiceProvider _serviceProvider;

    public CommandProcessor(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task Handle(ICommand command)
    {
        var handlerType = typeof(ICommandHandler<>)
            .MakeGenericType(command.GetType());

        dynamic handler = _serviceProvider.GetService(handlerType);

        return handler.Handle((dynamic)command);
    }
}

