using Dapper.FluentMap.Configuration;

namespace EmployeeApi.Infrastructure.DbModels.Mappings;

public static class DapperRegistration
{
    public static void Register(FluentMapConfiguration cfg)
    {
        cfg.AddMap(new EmployeeDbModelMap());
    }
}
