
namespace CQRS
{
    public class GetEmployeeQueryById: IQuery<GetEmployeeDto>
    {
        public string EmployeeNumber { get; set; }
    }
}
