using Code_First_Approach.Models;
using Microsoft.EntityFrameworkCore;

namespace Code_First_Approach.AppDbContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>Options) : base(Options) 
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
