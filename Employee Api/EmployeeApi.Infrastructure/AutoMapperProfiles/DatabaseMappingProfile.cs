using AutoMapper;
using EmployeeApi.Infrastructure.DbModels;
using EmployeeApi.Models;

namespace EmployeeApi.Infrastructure.AutoMapperProfiles;

public class DatabaseMappingProfile : Profile
{
    public DatabaseMappingProfile()
    {
        CreateMap<EmployeeDbModel, EmployeeModel>(MemberList.Destination);
    }
}
