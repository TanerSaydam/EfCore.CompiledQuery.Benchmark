using Bogus;
using Microsoft.EntityFrameworkCore;

namespace EfCore.CompiledQuery.Benchmark
{
    public class AppDbContext : DbContext
    {
        private static readonly Func<AppDbContext, long, Task<Customer?>> GetById =
            EF.CompileAsyncQuery((AppDbContext context, long id) =>
            context.Set<Customer>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        public async Task<Customer?> GetCustomerByIdCompiled(long id)
        {
            return await GetById(this,id);
        }

        public async Task<Customer?> GetCustomerById(long id)
        {
            return await Set<Customer>().AsNoTracking().FirstOrDefaultAsync(p=> p.Id == id);
        }
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
