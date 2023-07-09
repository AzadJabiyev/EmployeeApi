using Dapper.FluentMap.Mapping;

namespace EmployeeApi.Infrastructure.DbModels.Mappings;

public class EmployeeDbModelMap : EntityMap<EmployeeDbModel>
{
    public EmployeeDbModelMap()
    {
        Map(s => s.ID)
            .ToColumn("ID");

        Map(s => s.Name)
            .ToColumn("Name");

        Map(s => s.Age)
            .ToColumn("Age");
    }
}
