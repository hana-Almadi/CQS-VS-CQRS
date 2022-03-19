using System;
using System.Collections.Generic;

namespace CQRS
{ 
    public class GetEmployeeQuery : IQuery<List<GetEmployeeDto>>
    {
    public string JobTilte { get; set; }
    
    }
}
