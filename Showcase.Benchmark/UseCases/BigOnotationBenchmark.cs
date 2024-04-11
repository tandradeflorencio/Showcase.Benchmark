using BenchmarkDotNet.Attributes;

namespace Showcase.Benchmark.UseCases
{
    [RankColumn]
    [MemoryDiagnoser]
    public class BigOnotationBenchmark
    {
        [Benchmark(Description = "O(1)")]
        public void RunBigOne()
        {
            var firstNumber = 2;
            var secondNumber = 3;

            var sum = ExecuteSum(firstNumber, secondNumber);
        }

        [Benchmark(Description = "O(2^n)")]
        public void RunBigExponential()
        {
            var numberToSum = 10;

            ExecuteRecursiveSum(numberToSum);
        }

        private int ExecuteSum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private static int ExecuteRecursiveSum(int number)
        {
            const int MinValue = 0;

            if (number <= MinValue)
            {
                return number;
            }
            else
            {
                return number + ExecuteRecursiveSum(number - 1);
            }
        }
    }
}