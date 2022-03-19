
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace CQRS
{
    public class EmployeeQuery
    {
        
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public ObjectId Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public string JobTilte { get; set; }

        public EmployeeQuery() { }

        public EmployeeQuery(string employeeNumber, string name, string jobTilte)
        {
            Name = name;
            EmployeeNumber = employeeNumber;
            JobTilte = jobTilte;
            CreateDate = DateTime.Now;
        }
    }
}

