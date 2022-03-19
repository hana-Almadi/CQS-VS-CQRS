using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class EmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, 
        List<GetEmployeeDto>>,IRequestHandler<GetEmployeeQueryById, GetEmployeeDto>
    {
        private readonly QueryDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeQueryHandler(QueryDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetEmployeeDto> Handle(GetEmployeeQueryById query,
            CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employee.FindAsync(_ => _.EmployeeNumber.
            Equals(query.EmployeeNumber));
            if(employee.Current != null)
            return _mapper.Map<GetEmployeeDto>(employee.FirstAsync().Result);
            else return null;
        }

        public async Task<List<GetEmployeeDto>> Handle(GetEmployeeQuery query, 
            CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employee.Find(_ => _.JobTilte.
            Equals(query.JobTilte)).ToListAsync();
            if(employee != null)
            return _mapper.Map<List<GetEmployeeDto>>(employee);
            else return new List<GetEmployeeDto>();
        }
    }
}
