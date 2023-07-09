using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Core.Commands.EmployeeCommand;
using EmployeeApi.Core.Queries;
using EmployeeApi.Models;

namespace EmployeeApi.Web.Services;

public class EmployeeControllerService : IEmployeeControllerService
{
    private ICommandProcessor _commandProcessor;
    private IQueryProcessor _queryProcessor;

    public EmployeeControllerService(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor)
    {
        _commandProcessor = commandProcessor ?? throw new ArgumentNullException(nameof(commandProcessor));
        _queryProcessor = queryProcessor ?? throw new ArgumentNullException(nameof(queryProcessor));
    }

    public async Task CreateAsync(EmployeeModel model)
    {
        if (String.IsNullOrEmpty(model.Name))
        {
            throw new ArgumentNullException(nameof(model.Name));
        }

        if (model.Age <= 0)
        {
            throw new ArgumentException($"{nameof(model.Age)} must be bigger than 0.");
        }

        var command = new EmployeeCommand
        {
            EmployeeModel = model
        };

        await _commandProcessor.Handle(command);
    }

    public async Task<List<EmployeeModel>> GetAllAsync()
    {
        var query = new GetAllEmployeesQuery();
        return await _queryProcessor.Handle(query);
    }
}
