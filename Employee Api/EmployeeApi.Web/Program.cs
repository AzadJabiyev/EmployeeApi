using Dapper.FluentMap;
using EmployeeApi.Core.Abstractions.CQRS;
using EmployeeApi.Core.Abstractions.Repositories;
using EmployeeApi.Core.CommandHandlers;
using EmployeeApi.Core.Commands.EmployeeCommand;
using EmployeeApi.Core.Processors;
using EmployeeApi.Core.Queries;
using EmployeeApi.Core.QueryHandlers;
using EmployeeApi.Infrastructure;
using EmployeeApi.Infrastructure.DbModels.Mappings;
using EmployeeApi.Models;
using EmployeeApi.Web.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
FluentMapper.Initialize(DapperRegistration.Register);

builder.Services.AddTransient<IDbConnection>(_ => new SqlConnection(
    configuration.GetConnectionString("EmployeeTask")));

#region Processor Injections
builder.Services.AddScoped<ICommandProcessor, CommandProcessor>();
builder.Services.AddScoped<IQueryProcessor, QueryProcessor>();
#endregion

#region CommandHandler Injection
builder.Services.AddScoped<ICommandHandler<EmployeeCommand>, EmployeeCommandHandler>();
#endregion

#region QueryHandler Injection
builder.Services.AddScoped<IQueryHandler<GetAllEmployeesQuery, List<EmployeeModel>>, EmployeeQueryHandler>();
#endregion

#region Service Injection
builder.Services.AddTransient<IEmployeeControllerService, EmployeeControllerService>();
#endregion

#region Repository Injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
