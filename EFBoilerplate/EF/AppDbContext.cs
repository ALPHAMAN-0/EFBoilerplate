using Microsoft.EntityFrameworkCore;
using EFBoilerplate.Models;
namespace EFBoilerplate.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // One DbSet per table. The tables are created by docker-sqlserver/scripts/*.sql
        public DbSet<Product> product { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Employee> employee { get; set; }
    }
}
