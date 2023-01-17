using Bogus;
using Microsoft.EntityFrameworkCore;

namespace EfCore.CompiledQuery.Benchmark
{
    public class AppDbContext : DbContext
    {        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                var faker = new Faker();
                var customers = new List<Customer>();
                for (var i = 0; i < 10_000; i++)
                {
                    customers.Add(new Customer
                    {
                        Id = i + 1,
                        Age = faker.Random.Number(10, 100),
                        Name = faker.Name.FullName()
                    });
                }

                builder.HasData(customers);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3BJ5GK9;Initial Catalog=EFCompiledQuery;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
