using Microsoft.EntityFrameworkCore;
using Tasks.Models;

namespace Tasks.Contexts
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = MSVLab02; Trusted_Connection = True; Encrypt = False");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
