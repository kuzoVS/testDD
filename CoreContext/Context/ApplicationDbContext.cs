using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using testDD.Models;

namespace testDD.Context
{
    public class YourDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        // Метод для создания миграций
        public void EnsurePersonsTableCreated()
        {
            Database.EnsureCreated();
        }
    }
}
