using AutoMapper;
using EmployeeForm.Dto;
using EmployeeForm.Models;

namespace EmployeeForm
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, CreateEmployeeDto>();
        }
    }
}
