

using AutoMapper;
using System.Collections.Generic;

namespace CQS_Pattern
{
    public class EmployeeService
    {
        private readonly ICommand<Employee> _command;
        private readonly IQuery<Employee,int> _query;
        private readonly IMapper _mapper; 

        public EmployeeService(ICommand<Employee> command, IQuery<Employee,int> query, IMapper mapper)
        {
            _command = command;
            _query = query; 
            _mapper = mapper;
        }

        public void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _query.GetById(updateEmployeeDto.EmployeeId);
            employee.JobTilte = updateEmployeeDto.JobTilte;
            _command.Update(employee);
        }
        public void InsertEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDto);
            _command.Insert(employee);
        }
        public GetEmployeeDto? GetEmployee(int EmployeeNumber)
        {
            var employee = _query.GetById(EmployeeNumber);
            if(employee!=null)
            return _mapper.Map<GetEmployeeDto>(employee);
            return null;
        }
        public List<GetEmployeeDto>? GetEmployees()
        {
            var employeeList = _query.GetAll();
            if(employeeList!=null &&employeeList.Count>0)
            return _mapper.Map<List<GetEmployeeDto>>(employeeList);
            return null;
        }

    }
}
