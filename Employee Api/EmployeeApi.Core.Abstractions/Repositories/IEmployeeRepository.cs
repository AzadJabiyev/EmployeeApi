using EmployeeApi.Models;

namespace EmployeeApi.Core.Abstractions.Repositories;

public interface IEmployeeRepository
{
    Task CreateAsync(EmployeeModel employee, CancellationToken cancellationToken);

    Task<List<EmployeeModel>> GetAllAsync(CancellationToken cancellationToken);
}
