using AutoMapper;
using Dapper;
using EmployeeApi.Core.Abstractions.Repositories;
using EmployeeApi.Models;
using System.Data;

namespace EmployeeApi.Infrastructure;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IMapper _mapper;

    private readonly IDbConnection _connection;

    public EmployeeRepository(IMapper mapper, IDbConnection connection)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public async Task CreateAsync(EmployeeModel employee, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        const string _query = @"Insert into [Employees] (Name, Age) Values(@Name, @Age)";
        await _connection.QueryAsync(_query, new
        {
            Name = employee.Name,
            Age = employee.Age
        });
    }

    public async Task<List<EmployeeModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        const string _query = @"Select * from Employees";
        var employees = await _connection.QueryAsync(_query);

        return _mapper.Map<List<EmployeeModel>>(employees);
    }
}
