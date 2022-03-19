

namespace CQS_Pattern
{
    public class CommandEmployee : ICommand<Employee>
    {
        private readonly CqsContext  _cqsContext;

        public CommandEmployee(CqsContext  cqsContext) {
            _cqsContext=cqsContext;   
        }

        public void Insert(Employee employee)
        {
            _cqsContext.Employee.Add(employee);
            _cqsContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _cqsContext.Employee.Update(employee);
            _cqsContext.SaveChanges();
        }
    }
}
