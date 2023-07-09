using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Models;

namespace EmployeeApi.Core.Commands.EmployeeCommand;

public class EmployeeCommand : ICommand
{
    public EmployeeModel EmployeeModel { get; set; }
}
