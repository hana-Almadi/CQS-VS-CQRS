using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS
{
    public class EmployeeCommand
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }

        public string JobTilte { get; set; }

        public EmployeeCommand() { }

        public EmployeeCommand(string employeeNumber, string name, string jobTilte)
        {
            Name = name;
            EmployeeNumber = employeeNumber;
            JobTilte = jobTilte;
            CreateDate = DateTime.Now;
        }
    }
}
