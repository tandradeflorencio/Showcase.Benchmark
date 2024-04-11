using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Showcase.Benchmark.UseCases
{
    [RankColumn]
    [MemoryDiagnoser]
    public class YieldReturnBenchmark
    {
        private const int Iterations = 1000;

        private readonly Consumer _consumer = new();

        [Benchmark]
        public void WithoutYieldReturn()
        {
            GenerateResults().Consume(_consumer);
        }

        [Benchmark]
        public void WithYieldReturn()
        {
            GenerateYieldResults().Consume(_consumer);
        }

        private IEnumerable<string> GenerateResults()
        {
            var result = new List<string>(Iterations);

            for (int index = 0; index < Iterations; index++)
                result.Add("Thiago Andrade Florencio");

            return result;
        }

        private IEnumerable<string> GenerateYieldResults()
        {
            for (int index = 0; index < Iterations; index++)
                yield return "Thiago Andrade Florencio";
        }
    }
}