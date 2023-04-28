using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.API.Data
{
    public class EmployeeInfoContext:DbContext
    {

        public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options):base(options)
        {
            
        }

        //table will be created as "Employees"
        public DbSet<Employees> Employees { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EmployeeInfoAPI;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
