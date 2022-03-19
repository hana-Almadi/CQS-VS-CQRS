
using Microsoft.EntityFrameworkCore;

namespace CQRS
{
    public class CommandDbContext:DbContext
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options) :
            base(options) { }
  
       public DbSet<EmployeeCommand> Employee { get; private set; }
    }
}
