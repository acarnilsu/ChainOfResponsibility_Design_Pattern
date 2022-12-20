using ChainOfResponsibility_Design_Pattern.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibility_Design_Pattern.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-O6Q5UAT;database=ChainOfRespDb; User Id=sa;Password=1234;");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
