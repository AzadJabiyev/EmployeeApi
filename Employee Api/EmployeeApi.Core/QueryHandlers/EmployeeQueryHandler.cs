using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Core.Abstractions.Repositories;
using EmployeeApi.Core.Queries;
using EmployeeApi.Models;

namespace EmployeeApi.Core.QueryHandlers;

public class EmployeeQueryHandler : IQueryHandler<GetAllEmployeesQuery, List<EmployeeModel>>
{
    private IEmployeeRepository _employeeRepository;

    public EmployeeQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }

    public async Task<List<EmployeeModel>> Handle(GetAllEmployeesQuery query) =>
             await _employeeRepository.GetAllAsync(default(CancellationToken));
}
