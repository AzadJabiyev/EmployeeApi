using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace EmployeeApi.DatabaseMigrator;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ExecuteDatabaseMigration();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The database was successfully migrated.");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cannot migrate the database: {e}");
            Console.ResetColor();
        }
    }

    private static void ExecuteDatabaseMigration()
    {
        var serviceProvider = CreateServices(GetConfiguration());
        using (IServiceScope scope = serviceProvider.CreateScope())
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp(1);
        }
    }

    private static IConfiguration GetConfiguration()
    {   
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string appSettingsPath = Path.Combine(basePath, "appsettings.json");

        // Load the configuration from the appsettings.json file
        return new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(appSettingsPath, optional: true, reloadOnChange: true)
            .Build();
    }

    private static IServiceProvider CreateServices(IConfiguration configuration)
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(builder => builder
                  .AddSqlServer()
                  .WithGlobalConnectionString(configuration.GetConnectionString("EmployeeTask"))
                  .WithMigrationsIn(Assembly.GetExecutingAssembly()))
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }
}
