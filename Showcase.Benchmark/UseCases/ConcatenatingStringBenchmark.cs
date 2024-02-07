using BenchmarkDotNet.Attributes;
using System.Text;

namespace Showcase.Benchmark.UseCases
{
    [RankColumn]
    [MemoryDiagnoser]
    public class ConcatenatingStringBenchmark
    {
        const int Iterations = 1000;

        [Benchmark]
        public string ConcatenatingString()
        {
            var result = string.Empty;

            for (int index = 0; index < Iterations; index++)
                result += "Thiago Andrade Florencio" + index;

            return result;
        }

        [Benchmark]
        public string ConcatenatingStringWithStringBuilder()
        {
            var stringBuilder = new StringBuilder();

            for (int index = 0; index < Iterations; index++)            
                stringBuilder.Append("Thiago Andrade Florencio" + index);            

            return stringBuilder.ToString();
        }

        [Benchmark]
        public string ConcatenatingStringWithGenericList()
        {
            var list = new List<string>(Iterations);

            for (int index = 0; index < Iterations; index++)
                list.Add("Thiago Andrade Florencio" + index);

            return list.ToString();
        }
    }
}
