using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS
{
    public class EmployeeCommandHandler : IRequestHandler<UpdateCommand>,
        IRequestHandler<CreateCommand>
    {
        private readonly CommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeCommandHandler(CommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCommand command,
            CancellationToken cancellationToken)
        {
            var employee = _dbContext.Employee.Where(c=>c.EmployeeNumber.
            Equals(command.EmployeeId)).FirstOrDefault();
            employee.JobTilte = command.JobTilte;
            _dbContext.Employee.Update(employee);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(CreateCommand command,
            CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<EmployeeCommand>(command);
            await _dbContext.Employee.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
