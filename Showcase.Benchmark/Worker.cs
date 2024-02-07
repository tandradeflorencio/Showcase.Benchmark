using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Showcase.Benchmark.UseCases;

namespace Showcase.Benchmark;

[RankColumn]
[MemoryDiagnoser]
public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        BenchmarkRunner.Run<ConcatenatingStringBenchmark>();

        await Task.CompletedTask;
    }
}
