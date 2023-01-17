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
        public Customer? GetById()
        {
            //using var context = new AppDbContext();
            //return context.GetCustomerById(Id);            
        }

        [Benchmark]
        public Customer? GetByIdCompiled()
        {
            //using var context = new AppDbContext();
            //return context.GetCustomerByIdCompiled(Id);
        }
    }
}
