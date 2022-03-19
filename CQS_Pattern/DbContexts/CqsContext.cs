

using Microsoft.EntityFrameworkCore;

namespace CQS_Pattern
{
    public class CqsContext :DbContext
    {
        public CqsContext(DbContextOptions<CqsContext> options) : base(options) { }
        
        public DbSet<Employee> Employee { get; set; }

    }
}
