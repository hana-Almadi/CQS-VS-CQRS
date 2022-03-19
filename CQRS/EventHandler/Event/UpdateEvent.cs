namespace CQRS
{
    public class UpdateEvent: Event
    {
        public string EmployeeId { get; set; }

        public string JobTilte { get; set; }
    }
}
