using AutoMapper;

namespace CQS_Pattern
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, GetEmployeeDto>();
        }
    }
}
