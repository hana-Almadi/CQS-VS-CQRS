using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS
{
    public class EmployeeService
    {
        private readonly IMediator _mediator;
        private readonly EventHandler _eventHandler;
        private readonly IMapper _mapper;

        public EmployeeService(IMediator mediator, EventHandler eventHandler,
            IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
            _eventHandler = eventHandler;
        }
        public async Task UpdateEmployee(UpdateCommand command)
        {
           await _mediator.Send(command);
           await _eventHandler.Push(_mapper.Map<UpdateEvent>(command));
        }
        public async Task InsertEmployee(CreateCommand command)
        {
            await _mediator.Send(command);
            await _eventHandler.Push(_mapper.Map<CreateEvent>(command));
        }
        public async Task<GetEmployeeDto> GetEmployee(GetEmployeeQueryById query)
        {
          return  await _mediator.Send(query);
        }
        public async Task<List<GetEmployeeDto>> GetEmployees(GetEmployeeQuery query)
        {
          return await _mediator.Send(query);
        }
    }
}
