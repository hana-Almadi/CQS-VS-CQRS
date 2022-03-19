namespace CQRS
{
    public class CreateEvent: Event
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string JobTilte { get; set; }
    }
}
