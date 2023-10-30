using AutoMapper;
using EmployeesTest.Data.Db.Enteties;
using EmployeesTest.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeesTest.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Employee, EmployeeView>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name));

            CreateMap<Employee, EditEmployeeView>()
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
               .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name));
        }
    }
}
