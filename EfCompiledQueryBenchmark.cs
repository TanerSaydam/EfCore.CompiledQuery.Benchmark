using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace EfCore.CompiledQuery.Benchmark
{
    [ShortRunJob,Config(typeof(Config))]
    public class EfCompiledQueryBenchmark
    {        
        public class Config : ManualConfig
        {
            public Config()
            {
                SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Trend);
            }
        }        
    }
}
