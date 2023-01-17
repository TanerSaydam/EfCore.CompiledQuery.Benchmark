using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace EfCore.CompiledQuery.Benchmark
{
    [Config(typeof(Config))]
    public class EfCompiledQueryBenchmark
    {
        private const long Id = 7000;
        public class Config : ManualConfig
        {
            public Config()
            {
                SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Trend);
            }
        }

        [Benchmark(Baseline = true)]
        public async Task<Customer?> GetById()
        {
            using var context = new AppDbContext();
            return await context.GetCustomerById(Id);
        }

        [Benchmark]
        public async Task<Customer?> GetByIdCompiled()
        {
            using var context = new AppDbContext();
            return await context.GetCustomerByIdCompiled(Id);
        }
    }
}
