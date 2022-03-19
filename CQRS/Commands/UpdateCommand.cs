namespace CQRS
{
    public class UpdateCommand:ICommand
    {
        public string EmployeeId { get; set; }

        public string JobTilte { get; set; }
    }
}
