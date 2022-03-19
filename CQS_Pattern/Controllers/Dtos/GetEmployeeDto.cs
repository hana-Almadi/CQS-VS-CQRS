

using System;

namespace CQS_Pattern
{
    public class GetEmployeeDto
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string JobTilte { get; set; }
    }
}
