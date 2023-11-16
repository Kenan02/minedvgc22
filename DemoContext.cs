using Microsoft.EntityFrameworkCore;

namespace Generic_Employee_Dashboard
{
    public class DemoContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=C:\temps\demo.db");
       
    }
}
