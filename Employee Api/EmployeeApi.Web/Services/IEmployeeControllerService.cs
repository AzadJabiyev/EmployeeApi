using EmployeeApi.Models;

namespace EmployeeApi.Web.Services;

public interface IEmployeeControllerService
{
    Task CreateAsync(EmployeeModel model);

    Task<List<EmployeeModel>> GetAllAsync();
}
