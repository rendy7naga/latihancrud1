using Microsoft.EntityFrameworkCore;

namespace TestCrud1API.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TestCrud> Employees { get; set; }
    }
}
