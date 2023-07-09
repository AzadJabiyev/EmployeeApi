using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Core.Abstractions.Repositories;
using EmployeeApi.Core.Commands.EmployeeCommand;

namespace EmployeeApi.Core.CommandHandlers;

public class EmployeeCommandHandler : ICommandHandler<EmployeeCommand>
{
    private IEmployeeRepository _employeeRepository;

    public EmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    public async Task Handle(EmployeeCommand command)
    {
        await _employeeRepository.CreateAsync(command.EmployeeModel, default(CancellationToken));
    }
}
