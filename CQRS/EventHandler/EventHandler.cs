using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CQRS
{
    public class EventHandler
    {
        private readonly QueryDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventHandler(QueryDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task Push(Event @event)
        {
            if (@event is UpdateEvent)
            {
                var updateEvent = (@event as UpdateEvent);
                var filter = new BsonDocument("EmployeeNumber", updateEvent.EmployeeId);
                var update = Builders<EmployeeQuery>.Update.Set("JobTilte",updateEvent.JobTilte);
                await _dbContext.Employee.FindOneAndUpdateAsync(filter,update);
            }
            else if (@event is CreateEvent)
            {
              var employee = _mapper.Map<EmployeeQuery>(@event);
              await  _dbContext.Employee.InsertOneAsync(employee);
            }

        }
    }
}
