using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Models;

namespace EmployeeApi.Core.Queries;

public class GetAllEmployeesQuery : IQuery<List<EmployeeModel>>
{
}
