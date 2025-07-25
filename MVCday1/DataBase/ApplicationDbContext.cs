using Microsoft.EntityFrameworkCore;
using MVCday1.Controllers;
using MVCday1.Models;

namespace MVCday1.DataBase
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3JA9N1H\\SQLEXPRESS;Database=MVCday1;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
        public DbSet <Employee> Employees { get; set; }
    }
}
