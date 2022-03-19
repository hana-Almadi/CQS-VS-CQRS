using AutoMapper;

namespace CQRS
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<CreateCommand, EmployeeCommand>();
            CreateMap<EmployeeQuery, GetEmployeeDto>();
            CreateMap<CreateEvent, EmployeeQuery>();
            CreateMap<UpdateEvent, EmployeeQuery>();
            CreateMap<UpdateCommand,UpdateEvent>();
            CreateMap<CreateCommand, CreateEvent>();
        }
    }
}
