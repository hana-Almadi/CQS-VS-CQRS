

using System.Collections.Generic;
using System.Linq;

namespace CQS_Pattern
{
    public class QueryEmployee : IQuery<Employee,int>
    {
        private readonly CqsContext _cqsContext;

        public QueryEmployee(CqsContext cqsContext)
        {
            _cqsContext = cqsContext;
        }
        public ICollection<Employee> GetAll()
        {
           return _cqsContext.Employee.ToList();
                
        }

        public Employee? GetById(int id)
        {
            return _cqsContext.Employee.Find(id);
        }
    }
}
