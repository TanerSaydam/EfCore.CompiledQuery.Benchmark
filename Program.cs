using BenchmarkDotNet.Running;

namespace EfCore.CompiledQuery.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<EfCompiledQueryBenchmark>();
            Console.WriteLine("Hello, World!");
        }
    }
}