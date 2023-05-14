using EFTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Jan Kowalski", Email = "jk@gmail.com", Address = "Zielona 2"},
                new Employee { Id = 2, Name = "Adam Nowak", Email = "an@gmail.com", Address = "Niebieska 13"}
                );
        }
    }
}
