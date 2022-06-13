using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
    }

    public class DemoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Test");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasData(
                new Provider()
                {
                    Name = "fact1",
                    ProviderId = 1
                },
                new Provider()
                {
                    Name = "fact2",
                    ProviderId = 2
                }
              );
            modelBuilder.Entity<EnPart>().HasData(
                new EnPart
                {
                    Name = "پارت یک",
                    EnPartId = 1,
                    ProviderId = 1

                },
             new EnPart
             {
                 Name = "پارت دو",
                 EnPartId = 2,
                 ProviderId = 2

             }
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<EnPart> EnParts { get; set; }
    }
}