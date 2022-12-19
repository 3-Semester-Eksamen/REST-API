using Microsoft.EntityFrameworkCore;
using Class_Library;

namespace LåsRest.Models
{
    public class LåsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Use for Azure DB
            //options.UseSqlServer(Secrets.ConnectionString);

            //Use for localDB
            //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LåsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }

        public DbSet<Key> Keys { get; set; }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

    }
}
