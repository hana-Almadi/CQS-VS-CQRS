
namespace CQRS
{
    public class CreateCommand: ICommand
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string JobTilte { get; set; }
    }
}
